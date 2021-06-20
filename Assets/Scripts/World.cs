using System.Collections;

using UnityEngine;

public class World
{
	private GameObject mainObject;
	private Environment environment;
	private Tower tower;

	private readonly EnemyManager enemyManager = new EnemyManager();

	public Tower Tower { get { return tower; } }
	public Environment Environment { get { return environment; } }
	public EnemyManager EnemyManager { get { return enemyManager; } }

	public void Construct(WorldConfig config)
	{
		mainObject = new GameObject();
		mainObject.name = "World";

		environment = Object.Instantiate(config.Environment, mainObject.transform);

		var position = environment.GetWorldPosition(config.TowerPosition);
		tower = Object.Instantiate(config.TowerPrefab, mainObject.transform);
		tower.transform.position = position;
		tower.Construct(this);
	}

	public void Begin(Level level)
	{
		var executor = new LevelExecutor(this, level);
		executor.Begin(() =>
		{
			Debug.Log("Level End!");
		});
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
