using System.Collections;

using UnityEngine;

public class World
{
	private GameObject mainObject;

	private Environment environment;
	private EnemyManager enemyManager;
	private TowerManager towerManager;

	public Environment Environment { get { return environment; } }
	public EnemyManager EnemyManager { get { return enemyManager; } }
	public TowerManager TowerManager { get { return towerManager; } }

	public void Construct(LevelViewConfig config)
	{
		mainObject = new GameObject();
		mainObject.name = "World";

		var environmentConfig = config.EnvironmentConfig;

		environment = Object.Instantiate(environmentConfig.Prefab, mainObject.transform);
		environment.Construct(environmentConfig);

		enemyManager = new EnemyManager(this);
		towerManager = new TowerManager(this);

		foreach (var position in config.TowerPositions)
		{
			towerManager.Spawn(config.TowerConfig, position);
		}
	}

	public void Release()
	{
		if (mainObject != null)
		{
			Object.Destroy(mainObject);
		}
	}

	public void AddObject(Transform obj)
	{
		obj.parent = mainObject.transform;
	}

	public void AddRoutine(IEnumerator routine)
	{
		environment.StartCoroutine(routine);
	}

	public void RemoveRoutine(IEnumerator routine)
	{
		environment.StopCoroutine(routine);
	}

	public void OnUpdate()
	{
		towerManager.OnUpdate();
		enemyManager.OnUpdate();
	}
}
