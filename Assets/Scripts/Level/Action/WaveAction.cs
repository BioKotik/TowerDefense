using UnityEngine;

public abstract class WaveAction : ScriptableObject
{
	protected Level level;
	protected World world;

	public void Initialize(World world, Level level)
	{
		this.world = world;
		this.level = level;
	}

	public abstract void Do(System.Action callback);
}
