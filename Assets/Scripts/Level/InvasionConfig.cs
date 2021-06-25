using UnityEngine;

[CreateAssetMenu(fileName = "Enemies")]
public class InvasionConfig : ScriptableObject
{
	[SerializeField] private Wave[] waves;

	public int WaveCount { get { return waves.Length; } }

	public Wave GetWave(int index)
	{
		return waves[index];
	}
}
