using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen;
    Animator animator;

    public void OpenDoor(GameObject obj) {
        if (!isOpen){
            PlayerManager pm = obj.GetComponent<PlayerManager>();
            if (pm) {
                if (pm.keyCount > 0) {
                    isOpen = true;
                    pm.UseKey();
                    animator.SetTrigger("isOpen");
                }
            }
        }
    }

    void Start() {
        animator = GetComponent<Animator>();
    }
}
