using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class InteractableObject : MonoBehaviour
{
    public GameObject parentObject;
    public bool isInRange;
    public bool limitTimeOfUse;
    public int timeOfUse = 1;
    public bool destroyWhenUsed;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    public Dialogue dialogue;

    void Start() {

    }

    void Update() {
        if (isInRange) {
            if (Input.GetKeyDown(interactKey)) {
                interactAction.Invoke();
                if (limitTimeOfUse) {
                    timeOfUse--;
                }
                if (timeOfUse == 0) {
                    if (destroyWhenUsed) {
                        if (parentObject) {
                            Destroy(parentObject);
                        } else {
                            Destroy(this.gameObject);
                        }
                    } else {
                        Destroy(this);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            isInRange = false;
        }
    }

    public void TriggerDialogue() {
        FindAnyObjectByType<DialogueController>().StartDialogue(dialogue);
    }
    public void TriggerDialogue(int l) {
        FindAnyObjectByType<DialogueController>().StartDialogue(l, dialogue);
    }
    public void TriggerDialogue(int l, int m) {
        FindAnyObjectByType<DialogueController>().StartDialogue(l, m, dialogue);
    }
}
