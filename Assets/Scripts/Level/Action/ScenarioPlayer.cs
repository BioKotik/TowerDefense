
public class ScenarioPlayer
{
	private System.Action callback;
	private GameAction[] scenario;
	private World world;

	private ActionPlayer player;
	private int currentActionIndex = 0;
	private bool isPlaying;

	public bool IsPlaying()
	{
		return isPlaying;
	}

	public void SetCallback(System.Action callback)
	{
		this.callback = callback;
	}

	public void Initialize(World world, GameAction[] scenario)
	{
		UnityEngine.Debug.Assert(isPlaying == false, "[ScenarioPlayer] - Wrong call to Initialize while player is playing!");

		this.world = world;
		this.scenario = scenario;
	}

	public void Play()
	{
		isPlaying = true;
		currentActionIndex = 0;
		CreatePlayerAndPlay();
	}

	public void OnUpdate()
	{
		player.OnUpdate();
	}

	public void Release()
	{
		ReleasePlayer();
		this.world = null;
		this.scenario = null;
	}

	private void CreatePlayerAndPlay()
	{
		var currentAction = scenario[currentActionIndex];

		player = new ActionPlayer();
		player.Initialize(currentAction, world);
		player.SetCallback(OnActionExecutedHandler);
		player.Play();
	}

	private void OnActionExecutedHandler()
	{
		ReleasePlayer();

		++currentActionIndex;

		if (currentActionIndex >= scenario.Length)
		{
			isPlaying = false;
			callback?.Invoke();
			return;
		}

		CreatePlayerAndPlay();
	}

	private void ReleasePlayer()
	{
		player?.Release();
		player = null;
	}
}
