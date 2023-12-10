using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    Animator animator;
    public GameObject playerObject;
    public bool isOpen;
    public int keyGet = 1;
    public AudioClip soundEffect;

    public void OpenChest() {
        if (!isOpen){
            PlayerManager pm = playerObject.GetComponent<PlayerManager>();
            if (pm) {
                isOpen = true;
                pm.PickUpKey(keyGet);
                animator.SetTrigger("isOpen");
                AudioSource.PlayClipAtPoint(soundEffect, transform.position);
            } else {
                Debug.LogWarning("Player Object not found");
            }
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
}
