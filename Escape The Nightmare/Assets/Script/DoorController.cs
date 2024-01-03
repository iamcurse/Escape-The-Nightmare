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
    private Animator _animator;
    
    private InteractableObject _interactableObject;

    public Dialogue dialogue;

    private BoxCollider2D[] _boxCollider2D;
    private SpriteRenderer _spriteRenderer0;
    private SpriteRenderer _spriteRenderer1;
    private static readonly int IsOpen = Animator.StringToHash("isOpen");

    public void OpenDoorInteract() {
        if (!isOpen)
        {
            switch (needKey)
            {
                case true when !needSwitch:
                {
                    if (InventoryManager.Manager.CheckItem(key)) {
                        _interactableObject.dialogueTrigger.TriggerDialogue(0, dialogue);
                        InventoryManager.Manager.Remove(key);
                        OpenDoor();
                    } else {
                        _interactableObject.dialogueTrigger.TriggerDialogue(1, dialogue);
                    }

                    break;
                }
                case false when needSwitch:
                    _interactableObject.dialogueTrigger.TriggerDialogue(1, 2, dialogue);
                    break;
                case false when !needSwitch:
                    OpenDoor();
                    _interactableObject.dialogueTrigger.TriggerDialogue(3, dialogue);
                    break;
                case true when needSwitch:
                    Debug.LogWarning("Door: \"" + this.GameObject().name + "\" needKey and needSwitch cannot be true at the same time.");
                    break;
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
        _animator.SetBool(IsOpen, true);
        AudioSource.PlayClipAtPoint(doorOpenSound, transform.position);
        DoorOpenChanged();
    }
    public void OpenDoorNoSound() {
        isOpen = true;
        _animator.SetBool(IsOpen, true);
        DoorOpenChanged();
    }

    public void CloseDoor() {
        isOpen = false;
        _animator.SetBool(IsOpen, false);
        AudioSource.PlayClipAtPoint(doorCloseSound, transform.position);
        DoorCloseChanged();
    }

    private void DoorOpenChanged() {    
        if (_boxCollider2D[0]) {
            _boxCollider2D[0].isTrigger = true;
        }
        if (_spriteRenderer0) {
            _spriteRenderer0.enabled = false;
        }
        if (_spriteRenderer1) {
            _spriteRenderer1.enabled = true;
        }
    }
    private void DoorCloseChanged() {
        if (_boxCollider2D[0]) {
            _boxCollider2D[0].isTrigger = false;
        }
        if (_spriteRenderer0) {
            _spriteRenderer0.enabled = true;
        }
        if (_spriteRenderer1) {
            _spriteRenderer1.enabled = false;
        }
    }

    public void DoorEnterSceneChange() {
        if (isOpen) {
            if (isChangeScene) {
                if (sceneName != "") {
                    SceneManager.LoadScene(sceneName);
                } else {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }

    private void Start() {
        _interactableObject = this.GameObject().GetComponent<InteractableObject>();
        _animator = this.GameObject().GetComponent<Animator>();
        _boxCollider2D = this.GameObject().GetComponents<BoxCollider2D>();
        _spriteRenderer0 = transform.GetChild(1).GameObject().GetComponent<SpriteRenderer>();
        _spriteRenderer1 = transform.GetChild(2).GameObject().GetComponent<SpriteRenderer>();
        if (isOpenByDefault) {
            needKey = false;
            needSwitch = true;
            OpenDoorNoSound();
        }
    }
}