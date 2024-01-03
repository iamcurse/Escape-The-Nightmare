using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [FormerlySerializedAs("SceneName")] [ShowOnly] public string sceneName;
    [FormerlySerializedAs("InventoryPerScene")] public bool inventoryPerScene;
}
