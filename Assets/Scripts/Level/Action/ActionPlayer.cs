
public class ActionPlayer
{
	private System.Action callback;
	private GameAction action;
	private bool isPlaying;

	public bool IsPlaying()
	{
		return isPlaying;
	}

	public void SetCallback(System.Action callback)
	{
		this.callback = callback;
	}

	public void Play()
	{
		isPlaying = true;
		this.action.OnStart();
		CheckAndFlowIfComplete();
	}

	public void Initialize(GameAction action, World world)
	{
		UnityEngine.Debug.Assert(isPlaying == false, "[ActionPlayer] - Wrong call to Initialize while player is playing!");

		this.action = action;
		this.action.Initialize(world);
	}

	public void OnUpdate()
	{
		if (isPlaying)
		{
			this.action.OnUpdate();
			CheckAndFlowIfComplete();
		}
	}

	public void Release()
	{
		this.action.Release();
		this.action = null;
	}

	private void CheckAndFlowIfComplete()
	{
		if (action.IsComplete())
		{
			isPlaying = false;
			action.OnEnd();
			callback?.Invoke();
		}
	}
}
