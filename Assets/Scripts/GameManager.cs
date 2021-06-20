using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Level level;
	[SerializeField] private World world;

	[ContextMenu("Test")]
	private void Test()
	{
		var executor = new LevelExecutor(world, level);

		executor.Begin(() =>
		{
			print("Level End!");
		});
	}
}