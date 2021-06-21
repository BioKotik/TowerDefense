using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Level[] levels;
	[SerializeField] private int levelIndex;
	private Game game;
	

	private void Awake()
	{
		game = new Game();
		game.OnLevelPassed += OnLevelPassedHandler;
		game.OnLevelFailed += OnLevelFailedHandler;
	}

	private void Start()
	{
		game.Play(levels[levelIndex]);
	}

	private void Update()
	{
		if (game != null)
		{
			game.OnUpdate();
		}
	}

	private void OnLevelFailedHandler()
	{
		game.Play(levels[levelIndex]);
		print("Level Failed!");
	}

	private void OnLevelPassedHandler()
	{
		levelIndex = (levelIndex + 1) % levels.Length;
		game.Play(levels[levelIndex]);
		print("Level Passed!");
	}
}