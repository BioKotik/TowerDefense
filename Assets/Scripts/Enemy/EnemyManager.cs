using UnityEngine;

using System.Collections.Generic;

public class EnemyManager
{
	public event System.Action<Enemy> OnEnemyStop;
	public event System.Action<Enemy> OnEnemyDead;

	private readonly List<Enemy> enemies = new List<Enemy>();
	private readonly List<System.Action> deadClosures = new List<System.Action>();
	private readonly List<System.Action> stopClosures = new List<System.Action>();
	private World world;

	public int EnemyCount { get { return enemies.Count; } }

	public void Initialize(World world)
	{
		this.world = world;
	}

	public void OnUpdate()
	{
		var copy = new Enemy[enemies.Count];
		enemies.CopyTo(copy);

		foreach (var enemy in copy)
		{
			enemy.OnUpdate();
		}
	}

	public void Release()
	{
		for (int idx = 0; idx < enemies.Count; ++idx)
		{
			DestroyEnemy(idx);
		}

		enemies.Clear();
		stopClosures.Clear();
		deadClosures.Clear();
	}

	public Enemy GetEnemy(int index)
	{
		return enemies[index];
	}

	public Enemy Spawn(EnemyConfig config, Path path)
	{
		var enemy = Object.Instantiate(config.Prefab, world.Root);
		enemy.transform.position = path[0];
		enemy.Initialize(config);
		enemy.SetPath(path);

		System.Action deadClosure = () => { OnEnemyStoppedHandler(enemy); };
		System.Action stopClosure = () => { OnEnemyDeadHandler(enemy); };

		enemy.OnStop += deadClosure;
		enemy.OnDead += stopClosure;

		enemies.Add(enemy);
		deadClosures.Add(deadClosure);
		stopClosures.Add(stopClosure);

		return enemy;
	}

	private void OnEnemyStoppedHandler(Enemy enemy)
	{
		OnEnemyStop?.Invoke(enemy);

		var index = enemies.IndexOf(enemy);
		DestroyEnemy(index);
		enemies.Remove(enemy);
	}

	private void OnEnemyDeadHandler(Enemy enemy)
	{
		OnEnemyDead?.Invoke(enemy);

		var index = enemies.IndexOf(enemy);
		
		DestroyEnemy(index);
		enemies.Remove(enemy);
	}

	private void DestroyEnemy(int index)
	{
		var enemy = enemies[index];

		System.Action deadClosure = () => { OnEnemyStoppedHandler(enemy); };
		System.Action stopClosure = () => { OnEnemyDeadHandler(enemy); };

		enemy.OnStop += deadClosure;
		enemy.OnDead += stopClosure;

		Object.Destroy(enemy.gameObject);
	}
}
