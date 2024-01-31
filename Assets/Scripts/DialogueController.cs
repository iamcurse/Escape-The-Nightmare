using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    public Animator animator;
    private Queue<string> _lines;
    private Queue<string> _names;
    private bool _isRunning;
    private bool _isTyping;
    private static readonly int IsOpen = Animator.StringToHash("isOpen");
    private string _currentTexT;
    private const string HtmlAlpha = "<color=#00000000>";

    private void Start() {
        _lines = new Queue<string>();
        _names = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue) {
        foreach (var nameDialogue in dialogue.names) {
            _names.Enqueue(nameDialogue);
        }
        foreach (var lineDialogue in dialogue.lines) {
            _lines.Enqueue(lineDialogue);
        }
        
        if (!_isRunning)
            DisplayNextLines();
    }
    public void StartDialogue (string lineDialogue) {
        _names.Enqueue("");
        _lines.Enqueue(lineDialogue);
        
        if (!_isRunning)
            DisplayNextLines();
    }
    public void StartDialogue (string lineDialogue, string nameDialogue) {
        _names.Enqueue(nameDialogue);
        _lines.Enqueue(lineDialogue);
        
        if (!_isRunning)
            DisplayNextLines();
    }
    public void StartDialogue (int l, Dialogue dialogue) {
        _names.Enqueue(dialogue.names[l]);
        _lines.Enqueue(dialogue.lines[l]);
        
        if (!_isRunning)
            DisplayNextLines();
    }

    public void StartDialogue (int l, int m, Dialogue dialogue) {
        for (var i = l; i <= m; i++) {
            _names.Enqueue(dialogue.names[i]);
            _lines.Enqueue(dialogue.lines[i]);
        }

        if (!_isRunning)
            DisplayNextLines();
    }

    public void DisplayNextLines()
    {
        if (_isTyping == false)
        {
            _isRunning = true;
            if (!animator.GetBool(IsOpen))
            {
                animator.SetBool(IsOpen, true);
            }

            if (_lines.Count == 0)
            {
                EndDialogue();
                return;
            }

            var nameDialogue = _names.Dequeue();
            var lineDialogue = _lines.Dequeue();

            StopAllCoroutines();
            StartCoroutine(TypeLine(lineDialogue, nameDialogue));
        } else
        {
            StopAllCoroutines();
            _isTyping = false;
            dialogueText.text = _currentTexT;
        }
    }

    private IEnumerator TypeLine (string lineDialogue, string nameDialogue) {
        _isTyping = true;
        nameText.text = nameDialogue;
        dialogueText.text = "";
        
        _currentTexT = lineDialogue;
        int index = 0;

        foreach (var unused in lineDialogue.ToCharArray())
        {
            index++;
            dialogueText.text = _currentTexT;
            
            var displayText = dialogueText.text.Insert(index, HtmlAlpha);
            dialogueText.text = displayText;
            yield return new WaitForSeconds(0.05f);
        }

        dialogueText.text = _currentTexT;
        _isTyping = false;
    }

    private void EndDialogue() {
        _names.Clear();
        _lines.Clear();

        _isRunning = false;
        animator.SetBool(IsOpen, false);
    }
}
