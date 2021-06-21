
using System;
using UnityEngine;

public class Game
{
	public event System.Action OnLevelPassed;
	public event System.Action OnLevelFailed;

	private Player player;
	private World world;
	private LevelExecutor executor;

	public void Play(Level level)
	{
		Reset();

		player = new Player(level.PlayerConfig);
		world = new World();

		world.Construct(level.LevelViewConfig);
		
		executor = new LevelExecutor(world, level.BattleConfig);
		executor.Begin(OnLevelPassedHandler);

		world.EnemyManager.OnEnemyDead += OnEnemyDeadHandler;
		world.EnemyManager.OnEnemyStop += OnEnemyPassedHandler;
	}

	private void OnEnemyDeadHandler(Enemy enemy)
	{
		AddReward(enemy);
	}

	private void AddReward(Enemy enemy)
	{
		player.Coins += enemy.GetDeathReward();
		Debug.Log(player.Coins);
	}

	public void OnUpdate()
	{
		if (world != null)
		{
			world.OnUpdate();
		}
	}

	private void Reset()
	{
		if (world != null)
		{
			world.EnemyManager.OnEnemyDead -= OnEnemyDeadHandler;
			world.EnemyManager.OnEnemyStop -= OnEnemyPassedHandler;
			world.Release();
			world = null;
		}

		executor = null;

		player = null;
	}

	private void OnEnemyPassedHandler(Enemy enemy)
	{
		--player.Health;

		if (player.Health <= 0)
		{
			OnLevelFailed?.Invoke();
			Reset();
		}
	}

	private void OnLevelPassedHandler()
	{
		OnLevelPassed?.Invoke();
	}
}
