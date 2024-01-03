using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    private Queue<string> _lines;
    private Queue<string> _names;
    private bool _isRunning;
    private static readonly int IsOpen = Animator.StringToHash("isOpen");

    private void Start() {
        _lines = new Queue<string>();
        _names = new Queue<string>();
        
    }

    public void StartDialogue (Dialogue dialogue) {
        if (!_isRunning) {
            animator.SetBool(IsOpen, true);

            _names.Clear();
            _lines.Clear();

            foreach (var nameDialogue in dialogue.names) {
                _names.Enqueue(nameDialogue);
            }
            foreach (var lineDialogue in dialogue.lines) {
                _lines.Enqueue(lineDialogue);
            }
            
            DisplayNextLines();
        } else {
            foreach (var nameDialogue in dialogue.names) {
                _names.Enqueue(nameDialogue);
            }
            foreach (var lineDialogue in dialogue.lines) {
                _lines.Enqueue(lineDialogue);
            }
        }
    }
    public void StartDialogue (string lineDialogue) {
        if (!_isRunning) {
            animator.SetBool(IsOpen, true);

            _names.Clear();
            _lines.Clear();

            _names.Enqueue("");
            _lines.Enqueue(lineDialogue);
            
            DisplayNextLines();
        } else {
            _names.Enqueue("");
            _lines.Enqueue(lineDialogue);
        }
    }
    public void StartDialogue (string lineDialogue, string nameDialogue) {
        if (!_isRunning) {
            animator.SetBool(IsOpen, true);

            _names.Clear();
            _lines.Clear();

            _names.Enqueue(nameDialogue);
            _lines.Enqueue(lineDialogue);
            
            DisplayNextLines();
        } else {
            _names.Enqueue(nameDialogue);
            _lines.Enqueue(lineDialogue);
        }
    }
    public void StartDialogue (int l, Dialogue dialogue) {
        if (!_isRunning) {
            animator.SetBool(IsOpen, true);
            
            _names.Clear();
            _lines.Clear();

            _names.Enqueue(dialogue.names[l]);
            _lines.Enqueue(dialogue.lines[l]);

            DisplayNextLines();
        } else {
            _names.Enqueue(dialogue.names[l]);
            _lines.Enqueue(dialogue.lines[l]);
        }
    }

    public void StartDialogue (int l, int m, Dialogue dialogue) {
        if (!_isRunning) {
            animator.SetBool(IsOpen, true);

            _names.Clear();
            _lines.Clear();

            for (var i = l; i <= m; i++) {
                _names.Enqueue(dialogue.names[i]);
                _lines.Enqueue(dialogue.lines[i]);
            }
            DisplayNextLines();
        } else {
            for (var i = l; i <= m; i++) {
                _names.Enqueue(dialogue.names[i]);
                _lines.Enqueue(dialogue.lines[i]);
            }
        }
    }

    public void DisplayNextLines() {
        if (_lines.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        var nameDialogue = _names.Dequeue();
        var lineDialogue = _lines.Dequeue();
        
        StopAllCoroutines();
        StartCoroutine(TypeLine(lineDialogue, nameDialogue));
    }

    private IEnumerator TypeLine (string lineDialogue, string nameDialogue) {
        _isRunning = true;
        nameText.text = nameDialogue;
        dialogueText.text = "";
        foreach (var c in lineDialogue) {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void EndDialogue() {
        animator.SetBool(IsOpen, false);
        _isRunning = false;
    }
}
