using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "Path")]
public class Path : ScriptableObject
{
	[SerializeField] private List<Vector3> points;

	public Vector3 this[int index] { get { return points[index]; } set { points[index] = value; } }
	public int Length { get { return points.Count; } }

	public void Add(Vector3 point)
	{
		points.Add(point);
	}

	public void Remove(Vector3 point)
	{
		points.Remove(point);
	}
}
