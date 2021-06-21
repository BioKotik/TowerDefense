using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileConfig")]
public class ProjectileConfig : ScriptableObject
{
	[SerializeField] private int damage;
	[SerializeField] private float flySpeed;
	[SerializeField] private Projectile prefab;

	public Projectile Prefab { get { return prefab; } }
	public float FlySpeed { get { return flySpeed; } }
	public int Damage { get { return damage; } }
}
