using UnityEngine;

public class Level1Event : MonoBehaviour
{
    private InventoryManager _inventoryManager;
    private void Awake()
    {
        _inventoryManager = FindFirstObjectByType<InventoryManager>();
        _inventoryManager.ClearInventory();
    }
}
