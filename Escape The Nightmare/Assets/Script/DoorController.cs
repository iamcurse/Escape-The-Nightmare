using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public bool isOpenByDefault;
    public bool needKey = true;
    public bool needSwitch;
    [ShowOnly] public bool isOpen;
    public int keyNeed = 1;
    public bool isChangeScene;
    public string sceneName;
    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;
    Animator animator;
    public PlayerData playerData;

    InteractableObject iobj;
    
    public void OpenDoorWithKey() {
        if (!isOpen){
            iobj = transform.GetChild(0).gameObject.GetComponent<InteractableObject>();
            if (needKey && !needSwitch) {
                PlayerManager playerManager = FindObjectOfType<PlayerManager>().gameObject.GetComponent<PlayerManager>();
                if (playerManager.playerData.key >= keyNeed) {
                    iobj.TriggerDialogue("You Unlocked The Door!");
                    playerManager.UseKey(keyNeed);
                    OpenDoor();
                } else {
                    iobj.TriggerDialogue(0);
                }
            } else if (needSwitch && !needKey) {
                iobj.TriggerDialogue(0, 1);
            } else if (!needSwitch && !needKey) {
                OpenDoor();
                iobj.TriggerDialogue(2);
            } else if (needKey && needKey) {
                Debug.LogWarning("Door: \"" + this.GameObject().name + "\" needKey and needSwitch cannot be true at the same time.");
            }
        }
    }

    public void Switch(GameObject obj) {
        if (!isOpen) {
            OpenDoor();
        } else {
            CloseDoor();
        }
    }

    public void OpenDoor() {
        isOpen = true;
        animator.SetBool("isOpen", true);
        AudioSource.PlayClipAtPoint(doorOpenSound, transform.position);
        DoorOpenChanged();
    }
        public void OpenDoorNoSound() {
        isOpen = true;
        animator.SetBool("isOpen", true);
        DoorOpenChanged();
    }

    public void CloseDoor() {
        isOpen = false;
        animator.SetBool("isOpen", false);
        AudioSource.PlayClipAtPoint(doorCloseSound, transform.position);
        DoorCloseChanged();
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
        private void DoorCloseChanged() {
        BoxCollider2D boxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();
        if (boxCollider2D) {
            boxCollider2D.isTrigger = false;
        }
        SpriteRenderer spriteRenderer0 = transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer0) {
            spriteRenderer0.enabled = true;
        }
        SpriteRenderer spriteRenderer1 = transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer1) {
            spriteRenderer1.enabled = false;
        }
    }

    public void DoorEnterSceneChange() {
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
    private void Start() {
        animator = GetComponent<Animator>();
        if (isOpenByDefault) {
            needKey = false;
            needSwitch = true;
            OpenDoorNoSound();
        }
    }
}
