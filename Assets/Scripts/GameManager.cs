using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private WorldConfig config;
	[SerializeField] private Level level;
	private World world;

	private void Awake()
	{
		world = new World();
		world.Construct(config);
	}

	private void Start()
	{
		world.Begin(level);
	}

	private void Update()
	{
		world.OnUpdate();
	}
}