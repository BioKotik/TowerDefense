using UnityEngine;

[CreateAssetMenu(fileName = "Wave")]
public class Wave : ScriptableObject
{
	[SerializeField] private Path[] paths;
	[SerializeField] private WaveAction[] actions;
	
	public int ActionCount { get { return actions.Length; } }

	public WaveAction GetAction(int index)
	{
		return actions[index];
	}

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
