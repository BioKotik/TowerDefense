using UnityEngine;

[CreateAssetMenu(fileName = "CycleAction")]
public class CyclicalAction : WaveAction
{
	[SerializeField] private WaveAction[] actions;
	[SerializeField, Min(1)] private int cycleCount = 1;

	private System.Action callback;
	private int currentActionIndex;
	private int leftCycles;

	public override void Do(System.Action callback)
	{
		this.callback = callback;
		currentActionIndex = 0;
		leftCycles = cycleCount;

		var action = GetCurrentAction();
		Do(action);
	}

	private WaveAction GetCurrentAction()
	{
		return actions[currentActionIndex];
	}

	private void Do(WaveAction action)
	{
		action.Initialize(world, wave);
		action.Do(ActionDoneHandler);
	}

	private void ActionDoneHandler()
	{
		++currentActionIndex;

		if (currentActionIndex >= actions.Length)
		{
			--leftCycles;

			if (leftCycles > 0)
			{
				currentActionIndex = 0;
			}
			else
			{
				callback?.Invoke();
				return;
			}
		}

		var action = GetCurrentAction();
		Do(action);
	}
}
