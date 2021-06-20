using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
	[SerializeField] private int health;

	public int Health { get { return health; } }
}
