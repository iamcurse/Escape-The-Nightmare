using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    Animator animator;
    public bool isOpen;

    public void OpenChest(GameObject obj) {
        if (!isOpen){
            PlayerManager pm = obj.GetComponent<PlayerManager>();
            if (pm) {
                isOpen = true;
                pm.PickUpKey();
                animator.SetTrigger("isOpen");
            }
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
}
