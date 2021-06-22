using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Level[] levels;
	[SerializeField] private int levelIndex;
	[SerializeField] private UIConfig configUI;
	private Game game;
	private UIManager managerUI;
	private MainScreen mainScreen;
	private DefeatScreen defeatScreen;
	private VictoryScreen victoryScreen;


	private void Awake()
	{
		managerUI = new UIManager().Instantiate(configUI);
		mainScreen = managerUI.ScreenController.MainScreen;
		defeatScreen = managerUI.ScreenController.DefeatScreen;
		victoryScreen = managerUI.ScreenController.VictoryScreen;
		mainScreen.StartButton.OnClick += StartButtonHandler;
		defeatScreen.RestartButton.OnClick += RestartHandler;
		victoryScreen.NextLevelButton.OnClick += NextLevelHandler;
	}

	private void Update()
	{
		if (game != null)
		{
			game.OnUpdate();
		}
	}

	private void OnDestroy()
	{
		mainScreen.StartButton.OnClick -= StartButtonHandler;
		defeatScreen.RestartButton.OnClick -= RestartHandler;
		victoryScreen.NextLevelButton.OnClick -= NextLevelHandler;
		game.OnLevelPassed -= OnLevelPassedHandler;
		game.OnLevelFailed -= OnLevelFailedHandler;
	}

	private void StartButtonHandler()
	{
		CreateGame();
		managerUI.ScreenController.HideAll();
	}

	private void CreateGame()
	{
		game = new Game();
		game.Play(levels[levelIndex]);
		game.OnLevelPassed += OnLevelPassedHandler;
		game.OnLevelFailed += OnLevelFailedHandler;
	}

	private void RestartHandler()
	{
		game.Play(levels[levelIndex]);
		managerUI.ScreenController.HideAll();
	}

	private void NextLevelHandler()
	{
		levelIndex = (levelIndex + 1) % levels.Length;
		game.Play(levels[levelIndex]);
		managerUI.ScreenController.HideAll();
	}

	private void OnLevelFailedHandler()
	{
		defeatScreen.Show();
		print("Level Failed!");
	}

	private void OnLevelPassedHandler()
	{
		victoryScreen.Show();
		print("Level Passed!");
	}
}