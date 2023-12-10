using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string lines;
    public float textSpeed = 0.05f;

    private int index;

    void OnDisable()
    {
        textComponent.text = string.Empty;
        lines = "";
        //Array.Clear(lines, 0, lines.Length);
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            //if (textComponent.text == lines) {
                //NextLine();
            //} else {
                StopAllCoroutines();
                textComponent.text = lines;
                gameObject.SetActive(false);
            //}
        }
    }

    public void StartDialogue() {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void StartDialogue(string dialog) {
        gameObject.SetActive(true);
        lines = dialog;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() {
        foreach (char c in lines) {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    // void NextLine() {
    //     if (index < lines.Length -1) {
    //         index++;
    //         textComponent.text = string.Empty;
    //         StartCoroutine(TypeLine());
    //     } else {
    //         gameObject.SetActive(false);
    //     }
    // }
}
