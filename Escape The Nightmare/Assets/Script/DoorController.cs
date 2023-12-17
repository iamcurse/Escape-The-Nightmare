using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public bool isOpenByDefault;
    public bool needKey = true;
    public Item key;
    public bool needSwitch;
    [ShowOnly] public bool isOpen;
    public bool isChangeScene;
    public string sceneName;
    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;
    private Animator animator;
    public PlayerData playerData;

    private PlayerManager playerManager;
    private InteractableObject interactableObject;

    public Dialogue dialogue;

    private BoxCollider2D[] boxCollider2D;
    private SpriteRenderer spriteRenderer0;
    private SpriteRenderer spriteRenderer1;
    
    public void OpenDoorInteract() {
        if (!isOpen){
            if (needKey && !needSwitch) {
                if (InventoryManager.manager.CheckItem(key)) {
                    interactableObject.dialogueTrigger.TriggerDialogue(0, dialogue);
                    InventoryManager.manager.Remove(key);
                    OpenDoor();
                } else {
                    interactableObject.dialogueTrigger.TriggerDialogue(1, dialogue);
                }
            } else if (needSwitch && !needKey) {
                interactableObject.dialogueTrigger.TriggerDialogue(1, 2, dialogue);
            } else if (!needSwitch && !needKey) {
                OpenDoor();
                interactableObject.dialogueTrigger.TriggerDialogue(3, dialogue);
            } else if (needKey && needKey) {
                Debug.LogWarning("Door: \"" + this.GameObject().name + "\" needKey and needSwitch cannot be true at the same time.");
            }
        }
    }

    public void Switch() {
        if (needSwitch) {    
            if (!isOpen) {
                OpenDoor();
            } else {
                CloseDoor();
            }
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
        if (boxCollider2D[0]) {
            boxCollider2D[0].isTrigger = true;
        }
        if (spriteRenderer0) {
            spriteRenderer0.enabled = false;
        }
        if (spriteRenderer1) {
            spriteRenderer1.enabled = true;
        }
    }
    private void DoorCloseChanged() {
        if (boxCollider2D[0]) {
            boxCollider2D[0].isTrigger = false;
        }
        if (spriteRenderer0) {
            spriteRenderer0.enabled = true;
        }
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
        interactableObject = this.GameObject().GetComponent<InteractableObject>();
        playerManager = FindAnyObjectByType<PlayerManager>().GameObject().GetComponent<PlayerManager>();
        animator = this.GameObject().GetComponent<Animator>();
        boxCollider2D = this.GameObject().GetComponents<BoxCollider2D>();
        spriteRenderer0 = transform.GetChild(1).GameObject().GetComponent<SpriteRenderer>();
        spriteRenderer1 = transform.GetChild(2).GameObject().GetComponent<SpriteRenderer>();
        if (isOpenByDefault) {
            needKey = false;
            needSwitch = true;
            OpenDoorNoSound();
        }
    }
}
