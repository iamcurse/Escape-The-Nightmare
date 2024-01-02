using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneName;
    public void PlayGame() {
        if (sceneName != "") {
            SceneManager.LoadScene(sceneName);
            Debug.Log("Enter Scene: " + sceneName);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Enter Scene: " + NameFromIndex(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    private static string NameFromIndex(int buildIndex)
    {
    string path = SceneUtility.GetScenePathByBuildIndex(buildIndex);
    int slash = path.LastIndexOf('/');
    string name = path.Substring(slash + 1);
    int dot = name.LastIndexOf('.');
    return name.Substring(0, dot);
    }

    public void QuitGame () {
        Application.Quit();
    }
}
