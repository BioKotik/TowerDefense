using UnityEngine;

[CreateAssetMenu(fileName = "TowerUpgrade")]
public class TowerUpgrade : ScriptableObject
{
    public float attackSpeedBonus = 0;
    public float attackRangeBonus = 0;
    public Projectile projectileBonus = null;
    public Sprite towerSprite;
}
