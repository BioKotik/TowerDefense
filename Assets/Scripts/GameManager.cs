using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Level[] levels;
	private Game game;
	

	private void Awake()
	{
		game = new Game();

		game.OnLevelPassed += OnLevelPassedHandler;
		game.OnLevelFailed += OnLevelFailedHandler;
	}

	private void Start()
	{
		game.Play(levels[0]);
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
		print("Level Failed!");
	}

	private void OnLevelPassedHandler()
	{
		print("Level Passed!");
	}
}