using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public PlayerData playerData;
    private InventoryManager inventoryManager;

    private static string NameFromIndex(int BuildIndex)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }
    
    private void InventoryPerScene(bool ips) {
        if (ips) {
            inventoryManager.ClearInventory();
        }
    }

    private void Start() {
        playerData.SceneName = NameFromIndex(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Enter Scene: " + NameFromIndex(SceneManager.GetActiveScene().buildIndex));
        inventoryManager = FindFirstObjectByType<InventoryManager>();
        InventoryPerScene(playerData.InventoryPerScene);
    }
}
