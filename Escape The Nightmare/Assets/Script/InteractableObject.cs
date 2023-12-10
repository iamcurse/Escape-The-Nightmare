using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class InteractableObject : MonoBehaviour
{
    public bool isInRange;
    public bool isDestroyWhenUsed;
    public GameObject mainObject;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    void Start() {

    }

    void Update() {
        if (isInRange) {
            if (Input.GetKeyDown(interactKey)) {
                interactAction.Invoke();
                if (isDestroyWhenUsed) {
                    Destroy(mainObject);
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
}
