using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "UIConfig")]
public class UIConfig : ScriptableObject
{
    [SerializeField] private GameObject prefabUI;

    public GameObject PrefabUI { get { return prefabUI; } }
}
