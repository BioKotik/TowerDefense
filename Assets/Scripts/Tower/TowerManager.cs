using UnityEngine;

using System.Collections.Generic;

public class TowerManager
{
	private World world;
	private readonly List<Tower> towers = new List<Tower>();

	public void Initialize(World world)
	{
		this.world = world;
	}

	public void OnUpdate()
	{
		foreach (var tower in towers)
		{
			tower.OnUpdate();
		}
	}

	public void Release()
	{
		for (int idx = 0; idx < towers.Count; ++idx)
		{
			var tower = towers[idx];
			tower.Release();
			Object.Destroy(tower);
		}

		towers.Clear();
	}

	public Tower Spawn(TowerConfig config, Vector2Int position)
	{
		var tower = Object.Instantiate(config.Prefab, world.Root);
		tower.transform.position = world.EnvironmentManager.GetWorldPosition(position);
		tower.Initialize(config, world);

		towers.Add(tower);

		return tower;
	}
}
