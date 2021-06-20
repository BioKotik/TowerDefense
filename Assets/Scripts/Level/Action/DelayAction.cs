using System.Collections;

using UnityEngine;

[CreateAssetMenu(fileName = "DelayAction")]
public class DelayAction : WaveAction
{
	[SerializeField] private float seconds;
	private System.Action callback;

	public override void Do(System.Action callback)
	{
		this.callback = callback;
		world.AddRoutine(Delay());
	}

	private IEnumerator Delay()
	{
		yield return new WaitForSeconds(seconds);
		callback?.Invoke();
	}
}
