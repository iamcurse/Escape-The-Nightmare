using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    private Queue<string> lines;

    private bool isShowing;

    private PlayerController playerObject;

    void Start() {
        lines = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue) {
        DisablePlayerMove();
        isShowing = animator.GetBool("isOpen");
        if (!isShowing) {
            animator.SetBool("isOpen", true);
            nameText.text = dialogue.name;

            lines.Clear();

            foreach (string line in dialogue.lines) {
                lines.Enqueue(line);
            }
                DisplayNextLines();
        } else {
                foreach (string line in dialogue.lines) {
                lines.Enqueue(line);
            }
        }
    }
    public void StartDialogue (string line) {
        DisablePlayerMove();
        isShowing = animator.GetBool("isOpen");
        if (!isShowing) {
            animator.SetBool("isOpen", true);

            lines.Clear();

            lines.Enqueue(line);
            DisplayNextLines();
        } else {
            lines.Enqueue(line);
        }
    }

    public void StartDialogue (int l, Dialogue dialogue) {
        DisablePlayerMove();
        isShowing = animator.GetBool("isOpen");
        if (!isShowing) {
            animator.SetBool("isOpen", true);
            nameText.text = dialogue.name;

            lines.Clear();

            lines.Enqueue(dialogue.lines[l]);

            DisplayNextLines();
        } else {
            lines.Enqueue(dialogue.lines[l]);
        }
    }

    public void StartDialogue (int l, int m, Dialogue dialogue) {
        DisablePlayerMove();
        isShowing = animator.GetBool("isOpen");
        if (!isShowing) {
            animator.SetBool("isOpen", true);
            nameText.text = dialogue.name;

            lines.Clear();

            for (int i = l; i <= m; i++) {
                lines.Enqueue(dialogue.lines[i]);
            }
            DisplayNextLines();
        } else {
            for (int i = l; i <= m; i++) {
                lines.Enqueue(dialogue.lines[i]);
            }
        }
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

    private void DisablePlayerMove() {
        playerObject = FindAnyObjectByType<PlayerController>();
        playerObject.LockMovement();
    }
    private void EnablePlayerMove() {
        playerObject = FindAnyObjectByType<PlayerController>();
        playerObject.UnlockMovement();
    }

    public void EndDialogue() {
        animator.SetBool("isOpen", false);
        EnablePlayerMove();
    }
}
