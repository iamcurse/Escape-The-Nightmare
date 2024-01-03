using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private PlayerController _playerController;
    private InventoryManager _inventoryManager;
    private string _sceneName;

    // ReSharper disable Unity.PerformanceAnalysis
    public void GameOverTrigger(String sceneName) {
        if (!this.GameObject().activeSelf) {
            _inventoryManager = FindFirstObjectByType<InventoryManager>();
            _playerController = FindAnyObjectByType<PlayerController>();
            this.GameObject().SetActive(true);
            this._sceneName = sceneName;
            _inventoryManager.ClearInventory();
            Debug.Log("Current Scene: " + sceneName);
            _playerController.LockMovement();
        }
    }

    public void Retry() {
        SceneManager.LoadScene(_sceneName);
    }
    public void MainMenu() {
        SceneManager.LoadScene("Menu");
    }
}
