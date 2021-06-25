using System.Collections;

using UnityEngine;

public class World
{
	private GameObject mainObject;

	private EnemyManager enemyManager;
	private TowerManager towerManager;
	private EnvironmentManager environmentManager;

	public EnvironmentManager EnvironmentManager { get { return environmentManager; } }
	public EnemyManager EnemyManager { get { return enemyManager; } }
	public TowerManager TowerManager { get { return towerManager; } }
	public Transform Root { get { return mainObject.transform; } }

	public void Initialize(LevelViewConfig config)
	{
		mainObject = new GameObject();
		mainObject.name = "World";

		var environmentConfig = config.EnvironmentConfig;

		environmentManager = Object.Instantiate(environmentConfig.Prefab, mainObject.transform);
		environmentManager.Initialize(environmentConfig);

		enemyManager = new EnemyManager();
		enemyManager.Initialize(this);
		
		towerManager = new TowerManager();
		towerManager.Initialize(this);

		foreach (var position in config.TowerPositions)
		{
			towerManager.Spawn(config.TowerConfig, position);
		}
	}

	public void OnUpdate()
	{
		towerManager.OnUpdate();
		enemyManager.OnUpdate();
	}

	public void Release()
	{
		towerManager.Release();
		towerManager = null;

		enemyManager.Release();
		enemyManager = null;

		environmentManager.Release();
		environmentManager = null;

		Object.Destroy(mainObject);
	}
}
