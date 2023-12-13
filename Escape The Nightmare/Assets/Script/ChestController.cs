using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public bool isOpen;
    public int keyGet = 1;

    Animator animator;
    public AudioClip soundEffect;
    PlayerManager playerManager;
    InteractableObject interactableObject;

    public void OpenChest() {
        interactableObject = transform.GetChild(0).GameObject().GetComponent<InteractableObject>();
        if (!isOpen){
            if (playerManager) {
                isOpen = true;
                playerManager.PickUpKey(keyGet);
                animator.SetTrigger("isOpen");
                AudioSource.PlayClipAtPoint(soundEffect, transform.position);
            } else {
                Debug.LogWarning("Player Object not found");
            }
        }
    }

    void Start()
    {
        playerManager = FindAnyObjectByType<PlayerManager>().GameObject().GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
    }
}
