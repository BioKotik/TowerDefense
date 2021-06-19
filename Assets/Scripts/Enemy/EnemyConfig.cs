using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
	[SerializeField] private int hp;
	[SerializeField] private float movementSpeed;
	[SerializeField] private Enemy prefab;

	public int Hp { get { return hp; } }
	public float MovementSpeed { get { return movementSpeed; } }
	public Enemy Prefab { get { return prefab; } }
}
