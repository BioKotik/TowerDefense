using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	[SerializeField] private World world;
	[SerializeField] private Level level;

	private WaveExecutor executor;

	// TOWER
	// 
	// attack speed
	// attack radius
	// projectile (prefab)
	// move speed
	// damage
	// projectile follow enemy
	// attack transform

	// Upgrade
	// attack speed bonus (+ as) - 0
	// attack range bonus (+ ar) - 0
	// projectile bonus (change prefab) - null;


	// ENEMY
	//
	// hp
	// move speed
	// path

	// WAVE
	// path
	// Actions:
	// - spawn (enemy prefab with count of enemies)
	// - delay
	// wave end event

	// Level
	// waves[]
	// paths[]
	// event Level End

	// Level Manager
	// Level[]

	private void Awake()
	{
		Instance = this;
		executor = new WaveExecutor(level);
	}

	[ContextMenu("Spawn")]
	private void TestSpawn()
	{
		executor.Execute(world, level.Waves[0], () =>
		{
			Debug.Log("End");
		});
	}
}