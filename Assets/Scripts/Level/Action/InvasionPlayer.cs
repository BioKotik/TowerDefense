
public class InvasionPlayer
{
	private InvasionConfig config;
	private World world;

	private ScenarioPlayer player;
	private System.Action callback;
	private int currentWaveIndex;
	private bool isPlaying;

	public bool IsPlaying()
	{
		return isPlaying;
	}

	public void SetCallback(System.Action callback)
	{
		this.callback = callback;
	}

	public void Initialize(InvasionConfig config, World world)
	{
		this.config = config;
		this.world = world;
	}

	public void OnUpdate()
	{
		if (isPlaying)
		{
			this.player.OnUpdate();
		}
	}

	public void Release()
	{
		ReleasePlayer();
		this.config = null;
		this.world = null;
		this.isPlaying = false;
	}

	public void Play()
	{
		isPlaying = true;
		currentWaveIndex = 0;
		CreatePlayerAndPlay();
	}

	private void CreatePlayerAndPlay()
	{
		var currentWave = config.GetWave(currentWaveIndex);
		var scenario = currentWave.Scenario;

		player = new ScenarioPlayer();
		player.Initialize(world, scenario);
		player.SetCallback(OnWavePlayerEndHandler);
		player.Play();
	}

	private void OnWavePlayerEndHandler()
	{
		ReleasePlayer();

		++currentWaveIndex;

		if (currentWaveIndex >= config.WaveCount)
		{
			isPlaying = false;
			callback?.Invoke();
			return;
		}

		CreatePlayerAndPlay();
	}

	private void ReleasePlayer()
	{
		player?.Release();
		player = null;
	}
}
