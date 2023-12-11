using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void DialogueMessage(string msg) {
        dialogue.lines[0] = msg;
        TriggerDialogue();
    }

    public void TriggerDialogue() {
        FindAnyObjectByType<DialogueController>().StartDialogue(dialogue);
    }
    public void TriggerDialogue(string line) {
        FindAnyObjectByType<DialogueController>().StartDialogue(line);
    }
    public void TriggerDialogue(string line, string name) {
        FindAnyObjectByType<DialogueController>().StartDialogue(line, name);
    }
    public void TriggerDialogue(int l) {
        FindAnyObjectByType<DialogueController>().StartDialogue(l, dialogue);
    }
    public void TriggerDialogue(int l, int m) {
        FindAnyObjectByType<DialogueController>().StartDialogue(l, m, dialogue);
    }
}
