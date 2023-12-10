using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Dialogue dialogObject;
    public int keyCount;

    public void PickUpKey(int key) {
        keyCount += key;
        if (key == 1) {
            Debug.Log("Picked up " + key + " Key");
            dialogObject.StartDialogue("Picked up " + key + " Key");
        } else {
            Debug.Log("Picked up " + key + " Keys");
            dialogObject.StartDialogue("Picked up " + key + " Keys");
        }
    }
    public void UseKey(int key) {
        keyCount -= key;
        if (key == 1) {
            Debug.Log(key + " Key is Used");
        } else {
            Debug.Log(key + " Keys is Used");
        }
    }
}
