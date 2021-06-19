using UnityEngine;

public class World : MonoBehaviour
{
	[SerializeField] private Tower tower;
	private EnemyManager enemyManager = new EnemyManager();

	public EnemyManager EnemyManager { get { return enemyManager; } }

	private void Update()
	{
		tower.enemy = enemyManager.GetEnemyByIndex(0);
	}
}
