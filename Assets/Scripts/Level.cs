using UnityEngine;

[CreateAssetMenu(fileName = "Level")]
public class Level : ScriptableObject
{
	[SerializeField] private PlayerConfig playerConfig;
	[SerializeField] private LevelViewConfig levelViewConfig;
	[SerializeField] private BattleConfig battleConfig;

	public PlayerConfig PlayerConfig { get { return playerConfig; } }
	public BattleConfig BattleConfig { get { return battleConfig; } }
	public LevelViewConfig LevelViewConfig { get { return levelViewConfig; } }
}
