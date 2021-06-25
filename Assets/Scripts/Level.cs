using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Level")]
public class Level : ScriptableObject
{
	[SerializeField] private PlayerConfig playerConfig;
	[SerializeField] private LevelViewConfig levelViewConfig;
	[SerializeField, FormerlySerializedAs("battleConfig")] private InvasionConfig invasionConfig;

	public PlayerConfig PlayerConfig { get { return playerConfig; } }
	public InvasionConfig InvasionConfig { get { return invasionConfig; } }
	public LevelViewConfig LevelViewConfig { get { return levelViewConfig; } }
}
