using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private PlayerManager _playerManager;
    public string sceneName;
    public void ChangeScene() {
        if (sceneName != "") {
            SceneManager.LoadScene(sceneName);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ChangeScene(string scene) {
        SceneManager.LoadScene(scene);
    }

}
