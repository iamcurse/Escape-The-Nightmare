using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PauseScript : MonoBehaviour
{
    private PlayerController _playerController;
    private InventoryManager _inventoryManager;
    private string _sceneName;
    private static bool _gamePause;
    [FormerlySerializedAs("PauseUI")] public GameObject pauseUI;

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (_gamePause) {
            Resume();
        } else {
            Pause();
        }
    }

    public void Retry() {
        Time.timeScale = 1f;
        _inventoryManager = FindFirstObjectByType<InventoryManager>();
        _inventoryManager.ClearInventory();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    private void Resume() {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        _gamePause = false;
    }
    private void Pause() {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        _gamePause = true;
    }
    
}
