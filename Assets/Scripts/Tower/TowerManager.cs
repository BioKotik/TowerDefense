using UnityEngine;

using System.Collections.Generic;

public class TowerManager
{
	private World world;
	private List<Tower> towers = new List<Tower>();

	public TowerManager(World world)
	{
		this.world = world;
	}

	public Tower Spawn(TowerConfig config, Vector2Int position)
	{
		var tower = Object.Instantiate(config.Prefab);
		tower.transform.position = world.Environment.GetWorldPosition(position);
		tower.Construct(config, world);

		world.AddObject(tower.transform);
		towers.Add(tower);

		return tower;
	}

	public void OnUpdate()
	{
		foreach (var tower in towers)
		{
			tower.OnUpdate();
		}
	}
}
