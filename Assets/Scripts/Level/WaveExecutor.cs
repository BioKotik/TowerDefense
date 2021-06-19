public class WaveExecutor
{
	private System.Action callback;

	private Wave wave;
	private World world;

	private int currentActionIndex = 0;

	public WaveExecutor(World world, Wave wave)
	{
		this.wave = wave;
		this.world = world;
	}

	public void Begin(System.Action callback)
	{
		this.callback = callback;
		currentActionIndex = 0;

		var action = wave.GetAction(currentActionIndex);
		action.Initialize(world, wave);

		Execute(action);
	}

	private void ActionExecutedCallbackHandler()
	{
		++currentActionIndex;

		if (currentActionIndex >= wave.ActionCount)
		{
			callback?.Invoke();
			return;
		}

		var action = wave.GetAction(currentActionIndex);
		action.Initialize(world, wave);

		Execute(action);
	}

	private void Execute(WaveAction action)
	{
		action.Do(ActionExecutedCallbackHandler);
	}
}
