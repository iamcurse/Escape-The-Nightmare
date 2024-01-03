using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
    [ShowOnly] public bool isActive;
    [ShowOnly] public int numOfUsed;
    public bool isOneTimeUsed;
    public bool isActiveByDefault;
    public UnityEvent interactAction;

    private InteractableObject _interactableObject;

    private SpriteRenderer _spriteRenderer;
    public void Switch() {
        if (isOneTimeUsed) {
            if (numOfUsed == 0) {
                numOfUsed++;
                if (!isActive) {
                    Active();
                } else {
                    Deactivate();
                }
            } else {
                _interactableObject.TriggerLineNumberDialogue(2);
            }
        } else {
            if (!isActive) {
                Active();
            } else {
                Deactivate();
            }
        }
    }

private void Active() {
        isActive = true;
        _interactableObject.TriggerLineNumberDialogue(0);
        _spriteRenderer.flipX ^= true;
        interactAction.Invoke();
    }
private void Deactivate() {
        isActive = false;
        _interactableObject.TriggerLineNumberDialogue(1);
        _spriteRenderer.flipX ^= true;
        interactAction.Invoke();
}

    private void Start() {
        if (isActiveByDefault) {
            isActive = true;
            _spriteRenderer.flipX = true;
        }
        _interactableObject = this.GameObject().GetComponent<InteractableObject>();
        _spriteRenderer = this.GameObject().GetComponent<SpriteRenderer>();
    }
}
