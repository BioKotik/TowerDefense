using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Path))]
public class PathEditor : Editor
{
	private Path path;

	private void OnEnable()
	{
		path = (Path)target;
	}

	private void OnSceneGUI()
	{
		for (int idx = 0; idx < path.Length; ++idx)
		{
			path[idx] = Handles.FreeMoveHandle(path[idx], Quaternion.identity, 0.3f, Vector3.zero, Handles.CylinderHandleCap);
		}
	}
}
