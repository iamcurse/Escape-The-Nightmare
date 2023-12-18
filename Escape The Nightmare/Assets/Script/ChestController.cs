using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ChestController : MonoBehaviour
{
    public bool isOpen;
    private int Key(int k) {
        if (k < 0) {
            return k * -1;
        } else {
            return k;
        }
    }

    Animator animator;
    public AudioClip soundEffect;
    PlayerManager playerManager;
    public UnityEvent openChestAction;
    InteractableObject interactableObject;

    public Dialogue dialogue;

    public void OpenChest() {
        if (!isOpen){
            interactableObject.dialogueTrigger.TriggerDialogue(0, dialogue);
            openChestAction.Invoke();
        }
    }

    void Start()
    {
        playerManager = FindAnyObjectByType<PlayerManager>().GameObject().GetComponent<PlayerManager>();
        interactableObject = this.GameObject().GetComponent<InteractableObject>();
        animator = GetComponent<Animator>();
    }
}
