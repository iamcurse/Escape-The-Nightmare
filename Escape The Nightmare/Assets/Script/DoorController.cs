using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public bool isOpen;
    public int keyNeed = 1;
    public bool isChangeScene;
    public string sceneName;
    public GameObject player;
    public GameObject gobj;
    public GameObject doorFrameClosed;
    public GameObject doorFrameOpened;
    public AudioClip soundEffect;
    Animator animator;
    
    public void OpenDoor() {
        if (!isOpen){
            PlayerManager pm = player.GetComponent<PlayerManager>();
            if (pm) {
                if (pm.keyCount >= keyNeed) {
                    isOpen = true;
                    pm.UseKey(keyNeed);
                    animator.SetTrigger("isOpen");
                    AudioSource.PlayClipAtPoint(soundEffect, transform.position);
                    DoorOpenChanged();
                }
            }
        }
    }

    private void DoorOpenChanged() {
        BoxCollider2D boxCollider2D = gobj.GetComponent<BoxCollider2D>();
        if (boxCollider2D) {
            boxCollider2D.isTrigger = true;
        }
        SpriteRenderer spriteRenderer0 = doorFrameClosed.GetComponent<SpriteRenderer>();
        if (spriteRenderer0) {
            spriteRenderer0.enabled = false;
        }
        SpriteRenderer spriteRenderer1 = doorFrameOpened.GetComponent<SpriteRenderer>();
        if (spriteRenderer1) {
            spriteRenderer1.enabled = true;
        }
    }

    public void DoorEnter() {
        if (isChangeScene == true) {
            if (sceneName != null) {
            SceneManager.LoadScene(sceneName);
            Debug.Log("Enter Scene: " + sceneName);
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Debug.Log("Enter Scene: " + NameFromIndex(SceneManager.GetActiveScene().buildIndex + 1));
            }
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

    void Start() {
        animator = GetComponent<Animator>();
    }
}
