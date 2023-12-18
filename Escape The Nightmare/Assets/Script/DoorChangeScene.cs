using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class DoorChangeScene : MonoBehaviour
{
    [ShowOnly] public bool isInRange;
    public UnityEvent interactAction;

    void Update() {
        if (isInRange) {
            interactAction.Invoke();
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
