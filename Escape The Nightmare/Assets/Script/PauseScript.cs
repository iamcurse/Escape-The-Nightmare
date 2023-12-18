using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    private PlayerController playerController;
    private InventoryManager inventoryManager;
    private string sceneName;
    public static bool GamePause = false;
    public GameObject PauseUI;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GamePause) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Retry() {
        Time.timeScale = 1f;
        inventoryManager = FindFirstObjectByType<InventoryManager>();
        inventoryManager.ClearInventory();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    private void Resume() {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
    }
    private void Pause() {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
    }
    
}
