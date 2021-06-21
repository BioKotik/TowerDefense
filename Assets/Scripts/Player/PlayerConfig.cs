using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
	[SerializeField] private int health;
	[SerializeField] private int coins;
	

	public int Health { get { return health; } }

	public int Coins
	{
		get { return coins; }
		set { coins = value; }
	}
}
