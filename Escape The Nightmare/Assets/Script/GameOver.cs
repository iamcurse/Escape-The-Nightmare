using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    PlayerController playerController;
    public void GameOverTrigger(String sceneName) {
        if (!this.GameObject().activeSelf) {
            this.GameObject().SetActive(true);
            Debug.Log("Current Scene: " + sceneName);
            playerController = FindAnyObjectByType<PlayerController>();
            playerController.LockMovement();
        }
    }

    public void MainMenu() {
        SceneManager.LoadScene("Menu");
    }
}
