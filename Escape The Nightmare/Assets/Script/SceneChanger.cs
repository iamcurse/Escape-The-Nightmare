//@Arthor: 『Mr.Curse』
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private PlayerManager playerManager;
    public string sceneName;
    public void ChangeScene() {
        if (sceneName != "") {
            SceneManager.LoadScene(sceneName);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ChangeScene(string scene) {
        if (sceneName != "") {
            SceneManager.LoadScene(scene);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
