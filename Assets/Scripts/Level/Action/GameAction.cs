using UnityEngine;

public abstract class GameAction : ScriptableObject
{
	protected Wave wave;
	protected World world;

	private bool isComplete;

	public bool IsComplete()
	{
		return isComplete;
	}

	public void Initialize(World world)
	{
		this.world = world;
	}

	public virtual void OnStart()
	{
		isComplete = false;
	}

	public virtual void OnUpdate()
	{

	}

	public virtual void OnEnd()
	{

	}

	public virtual void Release()
	{
		wave = null;
		world = null;
		isComplete = false;
	}

	protected void SetComplete()
	{
		isComplete = true;
	}
}
