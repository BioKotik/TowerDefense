using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Tower tower;
	[SerializeField] private List<TowerUpgrades> towerUpgrades;

	[SerializeField] private World world;
	[SerializeField] private Level level;
	private WaveExecutor executor;

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

	private void Awake()
	{
		executor = new WaveExecutor(level);
	}

	[ContextMenu("Test")]
	private void Test()
	{
		executor.Execute(world, level.Waves[0], () =>
		{
			print("End");
		});
	}
}