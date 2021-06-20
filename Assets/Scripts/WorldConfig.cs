using UnityEngine;

[CreateAssetMenu(fileName = "WorldConfig")]
public class WorldConfig : ScriptableObject
{
	[SerializeField] private Vector2Int towerPosition;
	[SerializeField] private Tower towerPrefab;
	[SerializeField] private Environment map;

	public Vector2Int TowerPosition { get { return towerPosition; } }
	public Tower TowerPrefab { get { return towerPrefab; } }
	public Environment Environment { get { return map; } }
}
