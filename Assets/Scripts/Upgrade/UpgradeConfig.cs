using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "UpgradeConfig")]
public class UpgradeConfig : ScriptableObject
{
    public List<Upgrade> upgrades;
}
