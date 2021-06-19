using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TowerUpgrade", menuName = "GameData/TowerUprgrade", order = 1)]
public class TowerUpgrades : ScriptableObject
{
    public float attackSpeedBonus = 0;
    public float attackRangeBonus = 0;
    public Projectile projectileBonus = null;
}
