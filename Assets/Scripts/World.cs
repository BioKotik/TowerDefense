using UnityEngine;

public class World : MonoBehaviour
{
	[SerializeField] private Tower tower;
	private EnemyManager enemyManager = new EnemyManager();

	public EnemyManager EnemyManager { get { return enemyManager; } }

	private void Awake()
	{
		tower.Construct(this);
	}

	private void Update()
	{
		tower.OnUpdate();
	}
}
