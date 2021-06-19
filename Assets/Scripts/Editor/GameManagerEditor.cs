using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GameManager e = (GameManager)target;
        GUILayout.Space(5);

        if (GUILayout.Button("UpgradeTower"))
        {
            e.UpgradeTower();
        }
    }
}
