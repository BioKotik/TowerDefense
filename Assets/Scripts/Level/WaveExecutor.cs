public class WaveExecutor
{
	private System.Action callback;

	private Level level;
	private Wave wave;
	private World world;

	private int currentActionIndex = 0;

	public WaveExecutor(Level level)
	{
		this.level = level;
	}

	public void Execute(World world, Wave wave, System.Action callback)
	{
		this.callback = callback;
		this.wave = wave;
		this.world = world;

		currentActionIndex = 0;
		var action = wave.GetAction(currentActionIndex);
		action.Initialize(world, level);

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
		action.Initialize(world, level);

		Execute(action);
	}

	private void Execute(WaveAction action)
	{
		action.Do(ActionExecutedCallbackHandler);
	}
}
