using UnityEngine;

[CreateAssetMenu(fileName = "EnvironmentConfig")]
public class EnvironmentConfig : ScriptableObject
{
	[SerializeField] private EnvironmentManager prefab;
	[SerializeField] private Path[] paths;

	public EnvironmentManager Prefab { get { return prefab; } }
	public Path[] Paths { get { return paths; } }
}
