using UnityEngine;
using UnityEngine.Events;

public class Level2Event : MonoBehaviour
{
    public UnityEvent bottlePuzzle;
    private int _bottlePlace;
    public int BottlePlace { get => _bottlePlace; set => _bottlePlace = value; }

    public void PlaceBottle() {
        _bottlePlace++;
        Debug.Log("Bottle Place: " + _bottlePlace);
        if (_bottlePlace == 4) {
            bottlePuzzle.Invoke();
        }
    }
}
