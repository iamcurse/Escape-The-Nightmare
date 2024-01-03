using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public PlayerData playerData;
    private InventoryManager _inventoryManager;

    private static string NameFromIndex(int buildIndex)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(buildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }
    
    private void InventoryPerScene(bool ips) {
        if (ips) {
            _inventoryManager.ClearInventory();
        }
    }

    private void Start() {
        playerData.sceneName = NameFromIndex(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Enter Scene: " + NameFromIndex(SceneManager.GetActiveScene().buildIndex));
        _inventoryManager = FindFirstObjectByType<InventoryManager>();
        InventoryPerScene(playerData.inventoryPerScene);
    }
}
