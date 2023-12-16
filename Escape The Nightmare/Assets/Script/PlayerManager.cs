using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerData playerData;
    private DialogueTrigger dialogueTrigger;

    private void Start() {
        dialogueTrigger = this.GameObject().GetComponent<DialogueTrigger>();
    }
}
