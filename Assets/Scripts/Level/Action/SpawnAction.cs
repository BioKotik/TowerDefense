using UnityEngine;

public enum PathStrategy
{
	Implicit,
	Random
}

[CreateAssetMenu(fileName = "SpawnAction")]
public class SpawnAction : GameAction
{
	[SerializeField] private PathStrategy pathStrategy;
	[SerializeField] private int pathIndex;

	[SerializeField] private EnemyConfig config;

	public override void OnStart()
	{
		base.OnStart();

		var path = GetPath();
		world.EnemyManager.Spawn(config, path);

		SetComplete();
	}

	private Path GetPath()
	{
		switch (pathStrategy)
		{
			case PathStrategy.Implicit:
			{
				return world.EnvironmentManager.GetPath(pathIndex);
			}

			case PathStrategy.Random:
			default:
			{
				return world.EnvironmentManager.GetRandomPath();
			}
		}
	}
}
