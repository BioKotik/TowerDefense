using UnityEngine;

[CreateAssetMenu(fileName = "LevelWorld")]
public class LevelViewConfig : ScriptableObject
{
	[SerializeField] private Vector2Int[] towerPositions;
	[SerializeField] private TowerConfig towerConfig;
	[SerializeField] private EnvironmentConfig environmentConfig;

	public Vector2Int[] TowerPositions { get { return towerPositions; } }
	public TowerConfig TowerConfig { get { return towerConfig; } }
	public EnvironmentConfig EnvironmentConfig { get { return environmentConfig; } }
}
