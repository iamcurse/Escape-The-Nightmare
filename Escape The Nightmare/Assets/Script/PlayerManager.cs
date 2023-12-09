using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int keyCount;

    public void PickUpKey(int key) {
        keyCount += key;
        Debug.Log("Pucked up " + key + " Key");
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
