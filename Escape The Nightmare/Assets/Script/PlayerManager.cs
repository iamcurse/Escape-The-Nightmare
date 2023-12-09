using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int keyCount;

    public void PickUpKey() {
        keyCount++;
        Debug.Log("Pucked up Key");
    }
    public void UseKey() {
        keyCount--;
        Debug.Log("Key is Used");
    }
}
