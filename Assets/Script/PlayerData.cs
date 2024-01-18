using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [ShowOnly] public string sceneName;
    public bool inventoryPerScene;
}
