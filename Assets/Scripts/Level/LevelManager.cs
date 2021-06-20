using UnityEngine;

[System.Serializable]
public class LevelManager
{
	[SerializeField] private BattleConfig[] levels;
	private int currentLevelIndex;

	public void Start(int levelNumber)
	{
		var index = levelNumber - 1;
		var level = levels[index];	
	}
}
