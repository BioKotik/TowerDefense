using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Level[] levels;
	[SerializeField] private int levelIndex;

	private ActionPlayer actionPlayer = new ActionPlayer();

	private Game game;
	private World world;
	

	private void Awake()
	{
		//game = new Game();
		//game.OnLevelPassed += OnLevelPassedHandler;
		//game.OnLevelFailed += OnLevelFailedHandler;
	}

	private void Start()
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
	}

	private void Update()
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
}