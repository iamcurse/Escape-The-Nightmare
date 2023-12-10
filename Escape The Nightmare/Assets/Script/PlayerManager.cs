using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int keyCount;
    
    DialogueTrigger iobj;

    public void PickUpKey(int key) {
        keyCount += key;
        iobj = this.gameObject.GetComponent<DialogueTrigger>();
        if (key == 1) {
            iobj.dialogue.lines[9] = "You Picked Up 1 Key";
            iobj.TriggerDialogue(9);
        } else {
            iobj.dialogue.lines[9] = "You Picked Up " + key + " Keys";
            iobj.TriggerDialogue(9);
        }
    }
    public void UseKey(int key) {
        keyCount -= key;
        iobj.dialogue.lines[8] = "You Unlocked The Door";
        if (key == 1) {
            iobj.dialogue.lines[9] = "You Used 1 Key";
        } else {
            iobj.dialogue.lines[9] = "You Used " + key +" Key";
        }
        iobj.TriggerDialogue(8, 9);
    }
    public void UseKey(int key, string doorName) {
        keyCount -= key;
        if (key == 1) {
            
        } else {

        }
    }
}
