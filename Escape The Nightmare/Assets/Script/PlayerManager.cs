using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerData playerData;
    public TextMeshProUGUI textMeshProUGUI;
    private DialogueTrigger dialogueTrigger;

    public void PickUpKey(int key) {
        playerData.key += key;
        if (key == 1) {
            dialogueTrigger.TriggerDialogue("You Found 1 Key");
        } else {
            dialogueTrigger.TriggerDialogue("You Found " + key + " Keys");
        }
    }
    public void UseKey(int key) {
        playerData.key -= key;
        if (key == 1) {
            dialogueTrigger.TriggerDialogue("You Used 1 Key");
        } else {
            dialogueTrigger.TriggerDialogue("You Used " + key +" Key");
        }
    }
    private void UpdateKeyCounter() {
        textMeshProUGUI.text = playerData.key.ToString();
    }
    private void Update() {
        UpdateKeyCounter();
    }

    private void Start() {
        dialogueTrigger = this.GameObject().GetComponent<DialogueTrigger>();
    }
}
