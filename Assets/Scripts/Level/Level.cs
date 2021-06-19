using UnityEngine;

[CreateAssetMenu(fileName = "Level")]
public class Level : ScriptableObject
{
	[SerializeField] private Wave[] waves;
	[SerializeField] private Path[] paths;

	public Wave[] Waves { get { return waves; } }

	public Path GetPath(int index)
	{
		return paths[index];
	}

	public Path GetRandomPath()
	{
		var index = Random.Range(0, paths.Length);
		return GetPath(index);
	}
}
