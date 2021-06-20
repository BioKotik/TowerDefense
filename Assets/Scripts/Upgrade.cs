using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade")]
public class Upgrade : ScriptableObject
{
    public float attackSpeedBonus = 0;
    public float attackRangeBonus = 0;
    public Projectile projectileBonus = null;
    public Sprite towerSprite;
}
