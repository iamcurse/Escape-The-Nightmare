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
            iobj.TriggerDialogue("You Found 1 Key");
        } else {
            iobj.TriggerDialogue("You Found " + key + " Keys");
        }
    }
    public void UseKey(int key) {
        playerData.key -= key;
        if (key == 1) {
            iobj.TriggerDialogue("You Used 1 Key");
        } else {
            iobj.TriggerDialogue("You Used " + key +" Key");
        }
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
