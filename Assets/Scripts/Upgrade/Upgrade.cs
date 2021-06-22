using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade")]
public class Upgrade : ScriptableObject
{
    public float attackSpeedBonus = 0;
    public float attackRangeBonus = 0;
    public ProjectileConfig projectileConfig = null;
    public Sprite towerSprite;
}
