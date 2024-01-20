using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue(Dialogue insertDialogue) {
        FindAnyObjectByType<DialogueController>().StartDialogue(insertDialogue);
    }
    public void TriggerDialogue(string line) {
        FindAnyObjectByType<DialogueController>().StartDialogue(line);
    }
    public void TriggerDialogue(string line, string nameDialogue) {
        FindAnyObjectByType<DialogueController>().StartDialogue(line, nameDialogue);
    }
    public void TriggerDialogue(int l, Dialogue insertDialogue) {
        FindAnyObjectByType<DialogueController>().StartDialogue(l, insertDialogue);
    }
    public void TriggerDialogue(int l, int m, Dialogue insertDialogue) {
        FindAnyObjectByType<DialogueController>().StartDialogue(l, m, insertDialogue);
    }
}
