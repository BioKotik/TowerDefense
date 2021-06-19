using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Tower tower;
	[SerializeField] private List<TowerUpgrades> towerUpgrades;

	[SerializeField] private World world;
	[SerializeField] private Level level;

	public void UpgradeTower()
    {
        if (towerUpgrades.Count != 0)
        {
			tower.Upgrade(towerUpgrades[0]);
			towerUpgrades.RemoveAt(0);
		}
        else
        {
			print("Upgrades is empty");
        }
    }

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