using UnityEngine;
using UnityEngine.Events;

public class DoorChangeScene : MonoBehaviour
{
    [ShowOnly][SerializeField] private bool isInRange;
    public UnityEvent interactAction;

    private void Update() {
        if (isInRange) {
            interactAction.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            isInRange = false;
        }
    }
}
