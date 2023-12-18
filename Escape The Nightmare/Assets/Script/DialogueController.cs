//@Arthor: 『Mr.Curse』
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    private Queue<string> lines;
    private Queue<string> names;

    private bool isRunning;

    private PlayerController playerController;

    void Start() {
        playerController = FindAnyObjectByType<PlayerController>();
        lines = new Queue<string>();
        names = new Queue<string>();
        
    }

    public void StartDialogue (Dialogue dialogue) {
        if (!isRunning) {
            animator.SetBool("isOpen", true);

            names.Clear();
            lines.Clear();

            foreach (string name in dialogue.names) {
                names.Enqueue(name);
            }
            foreach (string line in dialogue.lines) {
                lines.Enqueue(line);
            }
                DisplayNextLines();
        } else {
            foreach (string name in dialogue.names) {
                names.Enqueue(name);
            }
            foreach (string line in dialogue.lines) {
                lines.Enqueue(line);
            }
        }
    }
    public void StartDialogue (string line) {
        if (!isRunning) {
            animator.SetBool("isOpen", true);

            names.Clear();
            lines.Clear();

            names.Enqueue("");
            lines.Enqueue(line);
            DisplayNextLines();
        } else {
            names.Enqueue("");
            lines.Enqueue(line);
        }
    }
    public void StartDialogue (string line, string name) {
        if (!isRunning) {
            animator.SetBool("isOpen", true);

            names.Clear();
            lines.Clear();

            names.Enqueue(name);
            lines.Enqueue(line);
            DisplayNextLines();
        } else {
            names.Enqueue(name);
            lines.Enqueue(line);
        }
    }
    public void StartDialogue (int l, Dialogue dialogue) {
        if (!isRunning) {
            animator.SetBool("isOpen", true);
            
            names.Clear();
            lines.Clear();

            names.Enqueue(dialogue.names[l]);
            lines.Enqueue(dialogue.lines[l]);

            DisplayNextLines();
        } else {
            names.Enqueue(dialogue.names[l]);
            lines.Enqueue(dialogue.lines[l]);
        }
    }

    public void StartDialogue (int l, int m, Dialogue dialogue) {
        if (!isRunning) {
            animator.SetBool("isOpen", true);

            names.Clear();
            lines.Clear();

            for (int i = l; i <= m; i++) {
                names.Enqueue(dialogue.names[i]);
                lines.Enqueue(dialogue.lines[i]);
            }
            DisplayNextLines();
        } else {
            for (int i = l; i <= m; i++) {
                names.Enqueue(dialogue.names[i]);
                lines.Enqueue(dialogue.lines[i]);
            }
        }
    }

    public void DisplayNextLines() {
        if (lines.Count == 0) {
            EndDialogue();
            return;
        }
        string name = names.Dequeue();
        string line = lines.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeLine(line, name));
    }

    IEnumerator TypeLine (string line, string name) {
        isRunning = true;
        nameText.text = name;
        dialogueText.text = "";
        foreach (char c in line.ToCharArray()) {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void DisablePlayerMove() {
        playerController.LockMovement();
    }
    private void EnablePlayerMove() {
        
        playerController.UnlockMovement();
    }

    public void EndDialogue() {
        animator.SetBool("isOpen", false);
        //EnablePlayerMove();
        isRunning = false;
    }
}
