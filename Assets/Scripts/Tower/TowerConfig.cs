using UnityEngine;

[CreateAssetMenu(fileName = "TowerConfig")]
public class TowerConfig : ScriptableObject
{
	[SerializeField] private Tower prefab;
	[SerializeField] private float attackRange;
	[SerializeField] private float attackSpeed;
	[SerializeField] private ProjectileConfig projectileConfig;

	public Tower Prefab { get { return prefab; } }
	public float AttackRange { get { return attackRange; } }
	public float AttackSpeed { get { return attackSpeed; } }
	public ProjectileConfig ProjectileConfig { get { return projectileConfig; } }
}
