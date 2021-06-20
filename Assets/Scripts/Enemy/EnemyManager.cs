﻿using UnityEngine;

using System.Collections.Generic;

public class EnemyManager
{
	public event System.Action<Enemy> OnEnemyStop;
	public event System.Action<Enemy> OnEnemyDead;

	private Transform parent;
	private List<Enemy> enemies = new List<Enemy>();

	public int EnemyCount { get { return enemies.Count; } }

	public Enemy GetEnemy(int index)
    {
        if (enemies.Count > 0)
        {
			return enemies[index];
        }
		return null;
    }

	public Enemy Spawn(EnemyConfig config, Path path)
	{
		var enemy = Object.Instantiate(config.Prefab);
		enemy.transform.position = path[0];
		enemy.Construct(config);
		enemy.SetPath(path);
		enemy.OnStop += () => { OnEnemyStoppedHandler(enemy); };
		enemy.OnDead += () => { OnEnemyDeadHandler(enemy); };

		enemies.Add(enemy);

		return enemy;
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
