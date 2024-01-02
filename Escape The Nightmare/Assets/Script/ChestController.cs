using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ChestController : MonoBehaviour
{
    public bool isOpen;
    private Animator _animator;
    public AudioClip soundEffect;
    public UnityEvent openChestAction;
    private InteractableObject _interactableObject;

    public Dialogue dialogue;
    private static readonly int IsOpen = Animator.StringToHash("isOpen");

    public void OpenChest() {
        if (!isOpen){
            _interactableObject.dialogueTrigger.TriggerDialogue(0, dialogue);
            AudioSource.PlayClipAtPoint(soundEffect, transform.position);
            _animator.SetBool(IsOpen, true);
            openChestAction.Invoke();
        }
    }

    private void Awake()
    {
        _interactableObject = this.GameObject().GetComponent<InteractableObject>();
        _animator = GetComponent<Animator>();
    }
}
