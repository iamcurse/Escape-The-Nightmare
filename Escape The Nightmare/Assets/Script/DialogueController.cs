using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    private Queue<string> lines;

    void Start() {
        lines = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue) {
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;

        lines.Clear();

        foreach (string line in dialogue.lines) {
            lines.Enqueue(line);
        }

        DisplayNextLines();
    }

    public void StartDialogue (int l, Dialogue dialogue) {
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;

        lines.Clear();

        lines.Enqueue(dialogue.lines[l]);

        DisplayNextLines();
    }

    public void StartDialogue (int l, int m, Dialogue dialogue) {
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;

        lines.Clear();

        for (int i = l; i <= m; i++) {
            lines.Enqueue(dialogue.lines[i]);
        }
        DisplayNextLines();
    }

    public void DisplayNextLines() {
        if (lines.Count == 0) {
            EndDialogue();
            return;
        }
        string line = lines.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeLine(line));
    }

    IEnumerator TypeLine (string line) {
        dialogueText.text = "";
        foreach (char c in line.ToCharArray()) {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void EndDialogue() {
        animator.SetBool("isOpen", false);
    }
}
