using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class InteractableObject : MonoBehaviour
{
    [ShowOnly] public bool isInRange;
    public bool limitTimeOfUse;
    public int timeOfUse = 1;
    public bool destroyWhenUsed;
    public GameObject objectToDestroy;
    public AudioClip soundEffect;
    public KeyCode interactKey = KeyCode.Mouse0;
    public UnityEvent interactAction;
    [FormerlySerializedAs("UseItemAction")] public UnityEvent useItemAction;

    public Dialogue dialogue;
    private DialogueController _dialogueController;
    [ShowOnly] public DialogueTrigger dialogueTrigger;
    private PlayerManager _playerManager;
    private GameOver _gameOver;

    private bool _trap;
    private static readonly int IsOpen = Animator.StringToHash("isOpen");

    private void Update() {
        if (isInRange) {
            if (!_dialogueController.animator.GetBool(IsOpen)) {
                if (Input.GetKeyDown(interactKey)) {
                    if (soundEffect) {
                        PlaySound();
                    }
                    interactAction.Invoke();
                    if (limitTimeOfUse) {
                        timeOfUse--;
                    }
                    if (timeOfUse == 0) {
                        if (destroyWhenUsed)
                        {
                            Destroy(objectToDestroy ? objectToDestroy : this.gameObject);
                        } else {
                            Destroy(this);
                        }
                    }
                }
            }

            if (_trap) {
                GameOver();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D doorCollider) {
        if (doorCollider.gameObject.CompareTag("Player")) {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D doorCollider) {
        if (doorCollider.gameObject.CompareTag("Player")) {
            isInRange = false;
        }
    }

    public void PlaySound() {
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
    }
    public void PlaySound(AudioClip sound) {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }

    public void TriggerTheDialogue(string line) {
        dialogueTrigger.TriggerDialogue(line);
    }
    public void TriggerAllDialogue() {
        dialogueTrigger.TriggerDialogue(dialogue);
    }
    public void TriggerLineNumberDialogue(int l) {
        dialogueTrigger.TriggerDialogue(l, dialogue);
    }
    public void TriggerDialogueRange(string range) {
        try {
            string[] lines = range.Split('-');
                
            if (lines.Length != 2 || Convert.ToInt32(lines[1]) > dialogue.lines.Length - 1) {
                Debug.LogWarning(this.gameObject.name + ": TriggerTheRangeDialogue Method's Input not correctly");
                return;
            }
            
            int l = Convert.ToInt32(lines[0]);
            int m = Convert.ToInt32(lines[1]);

            dialogueTrigger.TriggerDialogue(l, m, dialogue);
        } catch (FormatException) {
            Debug.LogWarning(this.gameObject.name + ": TriggerTheRangeDialogue Method's Input not correctly");
        }
    }

    public void AddItem(Item item) {
        InventoryManager.Manager.Add(item);
    }
    public void UseItem(Item item) {
        if (InventoryManager.Manager.CheckItem(item)) {
            InventoryManager.Manager.Remove(item);
            useItemAction.Invoke();
        } else {
            TriggerTheDialogue("You do not have the required item");
        }
    }
    public void UseItemNoRequireDialogue(Item item) {
        if (InventoryManager.Manager.CheckItem(item)) {
            InventoryManager.Manager.Remove(item);
            useItemAction.Invoke();
        }
    }

    public void DestroyThisObject() {
        Destroy(this.GameObject());
    }
    public void DestroyThisScript() {
        Destroy(this);
    }

    public void TrapActive() {
        _trap = true;
    }
    public void TrapDeactivate() {
        _trap = false;
    }

    public void GameOver() {
        _gameOver.GameOverTrigger(_playerManager.playerData.sceneName);
    }

    private void Start() {
        _playerManager = FindAnyObjectByType<PlayerManager>();
        _gameOver = FindAnyObjectByType<GameOver>(FindObjectsInactive.Include);
        _dialogueController = FindAnyObjectByType<DialogueController>();
        dialogueTrigger = FindAnyObjectByType<DialogueTrigger>();
    }
}
