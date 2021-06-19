using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Tower tower;
	[SerializeField] private List<TowerUpgrades> towerUpgrades;

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

	// TOWER
	// 
	// attack speed
	// attack radius
	// projectile (prefab)
	// move speed
	// damage
	// projectile follow enemy
	// attack transform
	// upgrades (scriptable object)
	
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
	// event Level End

	// Level Manager
	// Level[]

}