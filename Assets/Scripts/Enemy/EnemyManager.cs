using UnityEngine;

using System.Collections.Generic;

public class EnemyManager
{
	public event System.Action<Enemy> OnEnemyStop;
	public event System.Action<Enemy> OnEnemyDead;

	private List<Enemy> enemies = new List<Enemy>();

	public int EnemyCount { get { return enemies.Count; } }
	
	public Enemy GetEnemy(int index)
	{
		return enemies[index];
	}

	public void Spawn(EnemyConfig config, Path path)
	{
		var enemy = Object.Instantiate(config.Prefab);
		enemy.Construct(config);
		enemy.SetPath(path);
		enemy.OnStop += () => { OnEnemyStoppedHandler(enemy); };
		enemy.OnDead += () => { OnEnemyDeadHandler(enemy); };

		enemies.Add(enemy);
	}

	private void OnEnemyStoppedHandler(Enemy enemy)
	{
		OnEnemyStop?.Invoke(enemy);
		enemies.Remove(enemy);
		Object.Destroy(enemy.gameObject);
	}

	private void OnEnemyDeadHandler(Enemy enemy)
	{
		OnEnemyDead?.Invoke(enemy);
		enemies.Remove(enemy);
		Object.Destroy(enemy.gameObject);
	}
}
