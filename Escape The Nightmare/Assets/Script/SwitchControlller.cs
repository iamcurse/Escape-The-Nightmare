using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
    [ShowOnly] public bool isActive;
    public UnityEvent interactAction;
    public void Switch() {
        InteractableObject interactableObject = this.GameObject().GetComponent<InteractableObject>();
        SpriteRenderer spriteRenderer = this.GameObject().GetComponent<SpriteRenderer>();
        if (!isActive) {
            isActive = true;
            interactableObject.dialogueTrigger.TriggerDialogue("You Activated The Swtich");
            spriteRenderer.flipX = true;
            interactAction.Invoke();
        } else {
            spriteRenderer.flipX = false;
            isActive = false;
            interactableObject.dialogueTrigger.TriggerDialogue("You Deactivated The Swtich");
            interactAction.Invoke();
        }
    }

    private void Start() {

    }
}
