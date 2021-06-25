using UnityEngine;

[CreateAssetMenu(fileName = "Wave")]
public class Wave : ScriptableObject
{
	[SerializeField] private GameAction[] actions;
	
	public GameAction[] Scenario { get { return actions; } }
}
