using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

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
