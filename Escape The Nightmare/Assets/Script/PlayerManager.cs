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
    DialogueTrigger iobj;

    public void PickUpKey(int key) {
        playerData.key += key;
        if (key == 1) {
            iobj.dialogue.lines[9] = "You Found 1 Key";
            iobj.TriggerDialogue(9);
        } else {
            iobj.dialogue.lines[9] = "You Found " + key + " Keys";
            iobj.TriggerDialogue(9);
        }
    }
    public void UseKey(int key) {
        playerData.key -= key;
        iobj.dialogue.lines[8] = "You Unlocked The Door!";
        if (key == 1) {
            iobj.dialogue.lines[9] = "You Used 1 Key";
        } else {
            iobj.dialogue.lines[9] = "You Used " + key +" Key";
        }
        iobj.TriggerDialogue(8, 9);
    }
    private void UpdateKeyCounter() {
        textMeshProUGUI.text = playerData.key.ToString();
    }
    private void Update() {
        UpdateKeyCounter();
    }

    private void Start() {
        iobj = this.gameObject.GetComponent<DialogueTrigger>();
    }
}
