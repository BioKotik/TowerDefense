using UnityEngine;

[CreateAssetMenu(fileName = "CycleAction")]
public class CyclicalAction : GameAction
{
	[SerializeField] private GameAction[] actions;
	[SerializeField, Min(1)] private int cycleCount = 1;

	private ScenarioPlayer player;
	private int leftCycles;

	public override void OnStart()
	{
		base.OnStart();

		leftCycles = cycleCount;
		CreatePlayerAndPlay();
	}

	public override void OnUpdate()
	{
		base.OnUpdate();

		if (player != null)
		{
			player.OnUpdate();
		}
	}

	public override void OnEnd()
	{
		ReleasePlayer();
		base.OnEnd();
	}

	public override void Release()
	{
		ReleasePlayer();
		base.Release();
	}

	private void OnScenarioEndHandler()
	{
		ReleasePlayer();
		
		--leftCycles;

		if (leftCycles > 0)
		{
			CreatePlayerAndPlay();
		}
		else
		{
			SetComplete();
		}
	}

	private void CreatePlayerAndPlay()
	{
		player = new ScenarioPlayer();
		player.Initialize(world, actions);
		player.SetCallback(OnScenarioEndHandler);
		player.Play();
	}

	private void ReleasePlayer()
	{
		player?.Release();
		player = null;
	}
}
