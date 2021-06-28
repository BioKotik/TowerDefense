using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Level[] levels;
	[SerializeField] private int levelIndex;
	[SerializeField] private UIConfig configUI;
	private ActionPlayer actionPlayer = new ActionPlayer();
	private Game game;
	private UIManager managerUI;
	private MainScreen mainScreen;
	private DefeatScreen defeatScreen;
	private VictoryScreen victoryScreen;


	private void Awake()
	{
		game.OnLevelFailed += OnLevelFailedHandler;
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
	}	}

	private void RestartHandler()
	{
		var level = levels[0];
		var config = level.InvasionConfig;
		var wave = config.GetWave(0);
		var action = wave.Scenario[0];

		world = new World();
		world.Initialize(level.LevelViewConfig);

		actionPlayer.Initialize(action, world);
		actionPlayer.SetCallback(Handler);
		actionPlayer.Play();
		managerUI.ScreenController.HideAll();
	}

	private void NextLevelHandler()
	{
		actionPlayer?.OnUpdate();
		world?.OnUpdate();
	}

	private void Handler()
	{
		print("Action End!");
		world.Release();
		world = null;
		actionPlayer.Release();
		actionPlayer = null;
	}

	private void OnLevelPassedHandler()
	{
		victoryScreen.Show();
		print("Level Passed!");
	}
}