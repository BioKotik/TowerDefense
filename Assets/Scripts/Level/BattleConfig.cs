using UnityEngine;

[CreateAssetMenu(fileName = "Enemies")]
public class BattleConfig : ScriptableObject
{
	[SerializeField] private Wave[] waves;

	public int WaveCount { get { return waves.Length; } }

	public Wave GetWave(int index)
	{
		return waves[index];
	}
}
