using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Level[] levels;
	private int index;
	private Game game;
	

	private void Awake()
	{
		game = new Game();

		game.OnLevelPassed += OnLevelPassedHandler;
		game.OnLevelFailed += OnLevelFailedHandler;

		index = 0;
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
		game.Play(levels[index]);
		print("Level Failed!");
	}

	private void OnLevelPassedHandler()
	{
		index++;
		game.Play(levels[index]);
		print("Level Passed!");
	}
}