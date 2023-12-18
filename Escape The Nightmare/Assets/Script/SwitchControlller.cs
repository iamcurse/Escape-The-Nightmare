//@Arthor: 『Mr.Curse』
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
                    Active();
                } else {
                    Deactive();
                }
            } else {
                interactableObject.TriggerLineNumberDialogue(2);
            }
        } else {
            if (!isActive) {
                Active();
            } else {
                Deactive();
            }
        }
    }

private void Active() {
        isActive = true;
        interactableObject.TriggerLineNumberDialogue(0);
        if (spriteRenderer.flipX == false) {
            spriteRenderer.flipX = true;
        } else {
            spriteRenderer.flipX = false;
        }
        interactAction.Invoke();
    }
private void Deactive() {
        isActive = false;
        interactableObject.TriggerLineNumberDialogue(1);
        if (spriteRenderer.flipX == true) {
            spriteRenderer.flipX = false;
        } else {
            spriteRenderer.flipX = true;
        }
        interactAction.Invoke();
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
