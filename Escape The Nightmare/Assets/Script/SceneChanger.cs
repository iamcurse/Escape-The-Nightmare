using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private PlayerManager playerManager;
    public string sceneName;
    public void ChangeScene() {
        if (sceneName != "") {
            SceneManager.LoadScene(sceneName);
            Debug.Log("Enter Scene: " + sceneName);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Enter Scene: " + NameFromIndex(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }
        private static string NameFromIndex(int BuildIndex)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }

    private void Start() {
        playerManager = FindFirstObjectByType<PlayerManager>();
        playerManager.playerData.SceneName = NameFromIndex(SceneManager.GetActiveScene().buildIndex);
    }
}
