using UnityEngine;

[CreateAssetMenu(fileName = "Path")]
public class Path : ScriptableObject
{
	[SerializeField] private Vector3[] points;

	public Vector3 this[int index] { get { return points[index]; } set { points[index] = value; } }
	public int Length { get { return points.Length; } }
}
