//@Arthor: 『Mr.Curse』
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue(Dialogue dialogue) {
        FindAnyObjectByType<DialogueController>().StartDialogue(dialogue);
    }
    public void TriggerDialogue(string line) {
        FindAnyObjectByType<DialogueController>().StartDialogue(line);
    }
    public void TriggerDialogue(string line, string name) {
        FindAnyObjectByType<DialogueController>().StartDialogue(line, name);
    }
    public void TriggerDialogue(int l, Dialogue dialogue) {
        FindAnyObjectByType<DialogueController>().StartDialogue(l, dialogue);
    }
    public void TriggerDialogue(int l, int m, Dialogue dialogue) {
        FindAnyObjectByType<DialogueController>().StartDialogue(l, m, dialogue);
    }
}
