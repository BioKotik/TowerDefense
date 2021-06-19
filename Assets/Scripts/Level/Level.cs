using UnityEngine;

[CreateAssetMenu(fileName = "Level")]
public class Level : ScriptableObject
{
	[SerializeField] private Wave[] waves;

	public int WaveCount { get { return waves.Length; } }

	public Wave GetWave(int index)
	{
		return waves[index];
	}
}
