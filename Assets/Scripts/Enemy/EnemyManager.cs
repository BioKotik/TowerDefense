using UnityEngine;

using System.Collections.Generic;

public class EnemyManager
{
	public event System.Action<Enemy> OnEnemyStop;
	public event System.Action<Enemy> OnEnemyDead;

	private List<Enemy> enemies = new List<Enemy>();
	private World world;

	public int EnemyCount { get { return enemies.Count; } }

	public EnemyManager(World world)
	{
		this.world = world;
	}

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

		world.AddObject(enemy.transform);
		enemies.Add(enemy);

		return enemy;
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
