using UnityEngine;

using System.Collections.Generic;

public class ProjectileManager
{
	private List<Projectile> projectiles = new List<Projectile>();
	private World world;

	public ProjectileManager(World world)
	{
		this.world = world;
	}

	public Projectile Spawn(ProjectileConfig config, Enemy target, Vector3 position)
	{
		var projectile = Object.Instantiate(config.Prefab);
		projectile.transform.position = position;
		projectile.Construct(config);
		projectile.SetTarget(target);
		projectile.OnHit += () => { OnHitHandler(projectile); };

		world.AddObject(projectile.transform);
		projectiles.Add(projectile);

		return projectile;
	}

	private void OnHitHandler(Projectile projectile)
	{
		projectiles.Remove(projectile);
		Object.Destroy(projectile.gameObject);
	}
}
