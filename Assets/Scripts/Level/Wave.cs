using UnityEngine;

[CreateAssetMenu(fileName = "Wave")]
public class Wave : ScriptableObject
{
	[SerializeField] private WaveAction[] actions;
	
	public int ActionCount { get { return actions.Length; } }

	public WaveAction GetAction(int index)
	{
		return actions[index];
	}
}
