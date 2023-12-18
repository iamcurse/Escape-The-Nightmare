using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level2Event : MonoBehaviour
{
    public UnityEvent bootlePuzzle;
    private int bottlePlace;
    public int BottlePlace { get => bottlePlace; set => bottlePlace = value; }

    public void PlaceBottle() {
        bottlePlace++;
        Debug.Log("Bottle Place: " + bottlePlace);
        if (bottlePlace == 4) {
            bootlePuzzle.Invoke();
        }
    }
}
