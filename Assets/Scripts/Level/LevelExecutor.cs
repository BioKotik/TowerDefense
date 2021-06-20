
public class LevelExecutor
{
	private System.Action callback;

	private BattleConfig level;
	private World world;
	private int currentWaveIndex;

	public LevelExecutor(World world, BattleConfig level)
	{
		this.world = world;
		this.level = level;
	}

	public void Begin(System.Action callback)
	{
		this.callback = callback;
		this.currentWaveIndex = 0;

		world.EnemyManager.OnEnemyDead += OnBeforeEnemyDestroyHandler;
		world.EnemyManager.OnEnemyStop += OnBeforeEnemyDestroyHandler;

		BeginWave(currentWaveIndex);
	}

	private void BeginWave(int waveIndex)
	{
		var wave = level.GetWave(waveIndex);
		var waveExecutor = new WaveExecutor(world, wave);

		waveExecutor.Begin(OnWaveEndHandler);
	}

	private void OnWaveEndHandler()
	{
		UnityEngine.Debug.Log("Wave End!");

		++currentWaveIndex;

		if (currentWaveIndex >= level.WaveCount)
		{
			UnityEngine.Debug.Log("All Waves End!");

			if (IsLevelEnd())
			{
				EndLevel();
			}

			return;
		}

		BeginWave(currentWaveIndex);
	}

	private void OnBeforeEnemyDestroyHandler(Enemy obj)
	{
		UnityEngine.Debug.Log("Enemy Destroy!");

		if (IsLevelEnd())
		{
			EndLevel();
		}
	}

	private bool IsLevelEnd()
	{
		return currentWaveIndex >= level.WaveCount && world.EnemyManager.EnemyCount <= 1;
	}

	private void EndLevel()
	{
		world.EnemyManager.OnEnemyDead -= OnBeforeEnemyDestroyHandler;
		world.EnemyManager.OnEnemyStop -= OnBeforeEnemyDestroyHandler;

		callback?.Invoke();
	}
}
