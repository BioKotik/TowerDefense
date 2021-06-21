using UnityEngine;

[CreateAssetMenu(fileName = "EnvironmentConfig")]
public class EnvironmentConfig : ScriptableObject
{
	[SerializeField] private Environment prefab;
	[SerializeField] private Path[] paths;

	public Environment Prefab { get { return prefab; } }
	public Path[] Paths { get { return paths; } }
}
