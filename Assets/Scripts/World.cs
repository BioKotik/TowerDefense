using System.Collections;

using UnityEngine;

public class World
{
	private GameObject mainObject;

	private Tower tower;
	private Environment environment;
	private EnemyManager enemyManager;

	public Tower Tower { get { return tower; } }
	public Environment Environment { get { return environment; } }
	public EnemyManager EnemyManager { get { return enemyManager; } }

	public void Construct(LevelViewConfig config)
	{
		mainObject = new GameObject();
		mainObject.name = "World";

		enemyManager = new EnemyManager();
		environment = Object.Instantiate(config.Environment, mainObject.transform);

		var position = environment.GetWorldPosition(config.TowerPosition);
		tower = Object.Instantiate(config.TowerPrefab, mainObject.transform);
		tower.transform.position = position;
		tower.Construct(this);
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
		tower.OnUpdate();
	}
}
