using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public string doorName = "";
    public bool isOpen;
    public int keyNeed = 1;
    public bool isChangeScene;
    public string sceneName;
    public AudioClip soundEffect;
    Animator animator;

    InteractableObject iobj;
    
    public void OpenDoor() {
        if (!isOpen){
            iobj = transform.GetChild(0).gameObject.GetComponent<InteractableObject>();
            PlayerManager pm = FindObjectOfType<PlayerManager>().gameObject.GetComponent<PlayerManager>();
            if (pm) {
                if (pm.keyCount >= keyNeed) {
                    if (doorName == "") {
                        isOpen = true;
                            pm.UseKey(keyNeed);
                            animator.SetTrigger("isOpen");
                            AudioSource.PlayClipAtPoint(soundEffect, transform.position);
                            DoorOpenChanged();
                    } else {
                        isOpen = true;
                        pm.UseKey(keyNeed, doorName);
                        animator.SetTrigger("isOpen");
                        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
                        DoorOpenChanged();
                    }
                } else {
                    iobj.TriggerDialogue(0);
                }
            }
        }
    }

    private void DoorOpenChanged() {
        BoxCollider2D boxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();
        if (boxCollider2D) {
            boxCollider2D.isTrigger = true;
        }
        SpriteRenderer spriteRenderer0 = transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer0) {
            spriteRenderer0.enabled = false;
        }
        SpriteRenderer spriteRenderer1 = transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer1) {
            spriteRenderer1.enabled = true;
        }
    }

    public void DoorEnter() {
        if (isOpen) {
            if (isChangeScene == true) {
                if (sceneName != "") {
                    SceneManager.LoadScene(sceneName);
                    Debug.Log("Enter Scene: " + sceneName);
                } else {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    Debug.Log("Enter Scene: " + NameFromIndex(SceneManager.GetActiveScene().buildIndex + 1));
                }
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
