using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public bool isOpen;
    public int keyNeed = 1;
    public AudioClip soundEffect;
    Animator animator;
    
    public void OpenDoor(GameObject obj) {
        if (!isOpen){
            PlayerManager pm = obj.GetComponent<PlayerManager>();
            if (pm) {
                if (pm.keyCount >= keyNeed) {
                    isOpen = true;
                    pm.UseKey(keyNeed);
                    animator.SetTrigger("isOpen");
                    AudioSource.PlayClipAtPoint(soundEffect, transform.position);
                }
            }
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void Start() {
        animator = GetComponent<Animator>();
    }
}
