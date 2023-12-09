using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    Animator animator;
    public bool isOpen;
    public int keyGet = 1;
    public AudioClip soundEffect;

    public void OpenChest(GameObject obj) {
        if (!isOpen){
            PlayerManager pm = obj.GetComponent<PlayerManager>();
            if (pm) {
                isOpen = true;
                pm.PickUpKey(keyGet);
                animator.SetTrigger("isOpen");
                AudioSource.PlayClipAtPoint(soundEffect, transform.position);
            }
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
}
