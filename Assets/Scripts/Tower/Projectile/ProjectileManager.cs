using UnityEngine;

using System.Collections.Generic;

public class ProjectileManager
{
	private List<Projectile> projectiles = new List<Projectile>();
	private List<System.Action> closures = new List<System.Action>();
	private World world;

	public void Initialize(World world)
	{
		this.world = world;		
	}

	public void Release()
	{
		for (int idx = 0; idx < projectiles.Count; ++idx)
		{
			var projectile = projectiles[idx];
			var closure = closures[idx];

			projectile.OnHit -= closure;
		}

		projectiles.Clear();
		closures.Clear();
		world = null;
	}

	public Projectile Spawn(ProjectileConfig config, Enemy target, Vector3 position)
	{
		var projectile = Object.Instantiate(config.Prefab, world.Root);
		projectile.transform.position = position;
		projectile.Construct(config);
		projectile.SetTarget(target);

		System.Action closure = () => { OnHitHandler(projectile); };
		projectile.OnHit += closure;

		projectiles.Add(projectile);
		closures.Add(closure);

		return projectile;
	}

	private void OnHitHandler(Projectile projectile)
	{
		var index = projectiles.IndexOf(projectile);
		var closure = closures[index];

		projectile.OnHit -= closure;

		closures.RemoveAt(index);
		projectiles.Remove(projectile);

		Object.Destroy(projectile.gameObject);
	}
}
