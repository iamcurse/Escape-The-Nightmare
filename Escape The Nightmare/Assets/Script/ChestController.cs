using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public bool isOpen;
    public int keyGet = 1;

    Animator animator;
    public AudioClip soundEffect;
    InteractableObject iobj;

    public void OpenChest() {
        iobj = transform.GetChild(0).gameObject.GetComponent<InteractableObject>();
        if (!isOpen){
            PlayerManager pm = FindObjectOfType<PlayerManager>().gameObject.GetComponent<PlayerManager>();
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
