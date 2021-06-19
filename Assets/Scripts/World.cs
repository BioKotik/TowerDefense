using UnityEngine;

public class World : MonoBehaviour
{
	private EnemyManager enemyManager = new EnemyManager();

	public EnemyManager EnemyManager { get { return enemyManager; } }

	private void Update()
	{
		
	}
}
