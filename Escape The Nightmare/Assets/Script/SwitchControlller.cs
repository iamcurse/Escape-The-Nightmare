using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
    [ShowOnly] public bool isActive;
    public bool isActiveByDefault;
    public UnityEvent interactAction;

    private InteractableObject interactableObject;

    private SpriteRenderer spriteRenderer;
    public void Switch() {
        if (!isActive) {
            isActive = true;
            interactableObject.dialogueTrigger.TriggerDialogue("You Activated The Swtich");
            spriteRenderer.flipX = true;
            interactAction.Invoke();
        } else {
            isActive = false;
            interactableObject.dialogueTrigger.TriggerDialogue("You Deactivated The Swtich");
            spriteRenderer.flipX = false;
            interactAction.Invoke();
        }
    }

    private void Start() {
        interactableObject = this.GameObject().GetComponent<InteractableObject>();
        spriteRenderer = this.GameObject().GetComponent<SpriteRenderer>();

        if (isActiveByDefault) {
            isActive = true;
            spriteRenderer.flipX = true;
        }
    }
}
