using UnityEngine;

public enum PathStrategy
{
	Implicit,
	Random
}

[CreateAssetMenu(fileName = "SpawnAction")]
public class SpawnAction : WaveAction
{
	[SerializeField] private PathStrategy pathStrategy;
	[SerializeField] private int pathIndex;

	[SerializeField] private EnemyConfig config;

	public override void Do(System.Action callback)
	{
		var path = GetPath();
		world.EnemyManager.Spawn(config, path);

		callback?.Invoke();
	}

	private Path GetPath()
	{
		switch (pathStrategy)
		{
			case PathStrategy.Implicit:
			{
				return wave.GetPath(pathIndex);
			}

			case PathStrategy.Random:
			default:
			{
				return wave.GetRandomPath();
			}
		}
	}
}
