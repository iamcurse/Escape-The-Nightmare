using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Manager;
    public Inventory inventory;

    public Transform itemContent;
    public GameObject inventoryItem;

    private DialogueTrigger _dialogueTrigger;

    public void ClearInventory() {
        inventory.items.Clear();
    }

    public void Add(Item item) {
        string vowel = item.itemName.Substring(0, 1);
        if (vowel == "A" || vowel == "E" || vowel == "I" || vowel == "O" || vowel == "U"|| vowel == "e" || vowel == "i" || vowel == "o" || vowel == "u" || vowel == "u") {
            _dialogueTrigger.TriggerDialogue("You Found an " + item.itemName);
        } else {
            _dialogueTrigger.TriggerDialogue("You Found a " + item.itemName);
        }
        inventory.items.Add(item);
    }
    public bool CheckItem(Item item) {
        if (inventory.items.Contains(item)) {
            return true;
        } else {
            return false;
        }
    }
    public void Remove(Item item) {
        _dialogueTrigger.TriggerDialogue("You Use A " + item.itemName);
        inventory.items.Remove(item);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void ListItems() {
        foreach (Transform item in itemContent) {
            Destroy(item.gameObject);
        }

        foreach (var item in inventory.items) {
            try {
                var itemGameObject = Instantiate(inventoryItem, itemContent);
                var itemName = itemGameObject.transform.Find("ItemName").GetComponent<TMP_Text>();
                var itemIcon = itemGameObject.transform.Find("ItemIcon").GetComponent<Image>();

                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;
            } catch (NullReferenceException) {
                return;
            }
        }
    }

    private void Awake(){
        if (Manager == null)
        {
            Manager = this;
        }
        _dialogueTrigger = FindFirstObjectByType<DialogueTrigger>();
    }
    private void FixedUpdate() {
        ListItems();
    }
}
