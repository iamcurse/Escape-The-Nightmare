//@Arthor: 『Mr.Curse』
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private PlayerController playerController;
    private InventoryManager inventoryManager;
    private string sceneName;

    public void GameOverTrigger(String sceneName) {
        if (!this.GameObject().activeSelf) {
            inventoryManager = FindFirstObjectByType<InventoryManager>();
            playerController = FindAnyObjectByType<PlayerController>();
            this.GameObject().SetActive(true);
            this.sceneName = sceneName;
            inventoryManager.ClearInventory();
            Debug.Log("Current Scene: " + sceneName);
            playerController.LockMovement();
        }
    }

    public void Retry() {
        SceneManager.LoadScene(sceneName);
    }
    public void MainMenu() {
        SceneManager.LoadScene("Menu");
    }
}
