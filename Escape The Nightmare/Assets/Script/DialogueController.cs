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

            foreach (var nameLetter in dialogue.names) {
                _names.Enqueue(nameLetter);
            }
            foreach (var line in dialogue.lines) {
                _lines.Enqueue(line);
            }
            DisplayNextLines();
        } else {
            foreach (var nameLetter in dialogue.names) {
                _names.Enqueue(nameLetter);
            }
            foreach (var line in dialogue.lines) {
                _lines.Enqueue(line);
            }
        }
    }
    public void StartDialogue (string line) {
        if (!_isRunning) {
            animator.SetBool(IsOpen, true);

            _names.Clear();
            _lines.Clear();

            _names.Enqueue("");
            _lines.Enqueue(line);
            DisplayNextLines();
        } else {
            _names.Enqueue("");
            _lines.Enqueue(line);
        }
    }
    public void StartDialogue (string line, string nameDialogue) {
        if (!_isRunning) {
            animator.SetBool(IsOpen, true);

            _names.Clear();
            _lines.Clear();

            _names.Enqueue(nameDialogue);
            _lines.Enqueue(line);
            DisplayNextLines();
        } else {
            _names.Enqueue(nameDialogue);
            _lines.Enqueue(line);
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

            for (int i = l; i <= m; i++) {
                _names.Enqueue(dialogue.names[i]);
                _lines.Enqueue(dialogue.lines[i]);
            }
            DisplayNextLines();
        } else {
            for (int i = l; i <= m; i++) {
                _names.Enqueue(dialogue.names[i]);
                _lines.Enqueue(dialogue.lines[i]);
            }
        }
    }

    public void DisplayNextLines() {
        if (_lines.Count == 0) {
            animator.SetBool(IsOpen, false);
            _isRunning = false;
            return;
        }
        var nameDialogue = _names.Dequeue();
        var line = _lines.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeLine(line, nameDialogue));
    }

    private IEnumerator TypeLine (string line, string nameDialogue) {
        _isRunning = true;
        nameText.text = nameDialogue;
        dialogueText.text = "";
        foreach (var c in line) {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    // private void EndDialogue() {
    //     animator.SetBool(IsOpen, false);
    //     _isRunning = false;
    // }
}
