using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Path))]
public class PathEditor : Editor
{
	private Path path;

	private void OnEnable()
	{
		path = (Path)target;
		SceneView.duringSceneGui += OnSceneGUI;
	}

	private void OnDisable()
	{
		path = null;
		SceneView.duringSceneGui -= OnSceneGUI;
	}

	private void OnSceneGUI(SceneView view)
	{
		if (Event.current.alt && Event.current.type == EventType.MouseDown)
		{
			var ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
			var position = ray.origin + ray.direction * 10;


			path.Add(position);
		}

		for (int idx = 0; idx < path.Length; ++idx)
		{
			path[idx] = Handles.FreeMoveHandle(path[idx], Quaternion.identity, 0.3f, Vector3.zero, Handles.CylinderHandleCap);
		}
	}
}
