using UnityEngine;

public abstract class WaveAction : ScriptableObject
{
	protected Wave wave;
	protected World world;

	public void Initialize(World world, Wave wave)
	{
		this.world = world;
		this.wave = wave;
	}

	public abstract void Do(System.Action callback);
}
