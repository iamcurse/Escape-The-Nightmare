using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.PlayerLoop;

public class InteractableObject : MonoBehaviour
{
    [ShowOnly] public bool isInRange;
    public bool limitTimeOfUse;
    public int timeOfUse = 1;
    public bool destroyWhenUsed;
    public GameObject objectToDestroy;
    public AudioClip soundEffect;
    public KeyCode interactKey = KeyCode.Mouse0;
    public UnityEvent interactAction;

    public Dialogue dialogue;
    private DialogueController dialogueController;
    [ShowOnly] public DialogueTrigger dialogueTrigger;

    void Update() {
        if (isInRange) {
            if (!dialogueController.animator.GetBool("isOpen")) {
                if (Input.GetKeyDown(interactKey)) {
                    if (soundEffect) {
                        PlaySound();
                    }
                    interactAction.Invoke();
                    if (limitTimeOfUse) {
                        timeOfUse--;
                    }
                    if (timeOfUse == 0) {
                        if (destroyWhenUsed) {
                            if (objectToDestroy) {
                                Destroy(objectToDestroy);
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
    }

    private void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.gameObject.CompareTag("Player")) {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D) {
        if (collider2D.gameObject.CompareTag("Player")) {
            isInRange = false;
        }
    }

    public void PlaySound() {
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
    }

    public void TriggerTheDialogue(string line) {
        dialogueTrigger.TriggerDialogue(line);
    }
    public void TriggerAllDialogue() {
        dialogueTrigger.TriggerDialogue(dialogue);
    }
    public void TriggerLineNumberDialogue(int l) {
        dialogueTrigger.TriggerDialogue(l, dialogue);
    }
    public void TriggerDialogueRange(string range) {
        try {
            string[] lines = range.Split('-');
                
            if (lines.Length != 2 || Convert.ToInt32(lines[1]) > dialogue.lines.Length - 1) {
                Debug.LogWarning(this.gameObject.name + ": TriggerTheRangeDialoge Method's Input not correctly");
                return;
            }
            
            int l = Convert.ToInt32(lines[0]);
            int m = Convert.ToInt32(lines[1]);

            dialogueTrigger.TriggerDialogue(l, m, dialogue);
        } catch (FormatException) {
            Debug.LogWarning(this.gameObject.name + ": TriggerTheRangeDialoge Method's Input not correctly");
            return;
        }
    }

    private void Start() {
        dialogueController = FindAnyObjectByType<DialogueController>();
        dialogueTrigger = FindAnyObjectByType<DialogueTrigger>();
    }
}
