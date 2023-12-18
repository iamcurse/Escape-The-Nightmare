using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [ShowOnly] public string SceneName;
    public bool InventoryPerScene;
}
