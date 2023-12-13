using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
    [ShowOnly] public bool isActive;
    [ShowOnly] public int numOfUsed = 0;
    public bool isOneTimeUsed;
    public bool isActiveByDefault;
    public UnityEvent interactAction;

    private InteractableObject interactableObject;

    private SpriteRenderer spriteRenderer;
    public void Switch() {
        if (isOneTimeUsed) {
            if (numOfUsed == 0) {
                numOfUsed++;
                if (!isActive) {
                    isActive = true;
                    interactableObject.TriggerLineNumberDialogue(0);
                    spriteRenderer.flipX = true;
                    interactAction.Invoke();
                } else {
                    isActive = false;
                    interactableObject.TriggerLineNumberDialogue(1);
                    spriteRenderer.flipX = false;
                    interactAction.Invoke();
                }
            } else {
                interactableObject.TriggerLineNumberDialogue(2);
            }
        } else {
            if (!isActive) {
                isActive = true;
                interactableObject.TriggerLineNumberDialogue(0);
                spriteRenderer.flipX = true;
                interactAction.Invoke();
            } else {
                isActive = false;
                interactableObject.TriggerLineNumberDialogue(1);
                spriteRenderer.flipX = false;
                interactAction.Invoke();
            }
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
