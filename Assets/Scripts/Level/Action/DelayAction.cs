using UnityEngine;

[CreateAssetMenu(fileName = "DelayAction")]
public class DelayAction : GameAction
{
	[SerializeField] private float seconds;
	private float timer;

	public override void OnStart()
	{
		base.OnStart();
		timer = seconds;
	}

	public override void OnUpdate()
	{
		base.OnUpdate();
		timer -= Time.deltaTime;

		if (timer <= 0f)
		{
			timer = 0f;
			SetComplete();
		}
	}
}
