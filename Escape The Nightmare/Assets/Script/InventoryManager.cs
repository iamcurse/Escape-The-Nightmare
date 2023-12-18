//@Arthor: 『Mr.Curse』
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager manager;
    public Inventory inventory;

    public Transform ItemContent;
    public GameObject InventoryItem;

    private DialogueTrigger dialogueTrigger;

    public void ClearInventory() {
        inventory.Items.Clear();
    }

    public void Add(Item item) {
        string vovel = item.itemName.Substring(0, 1);
        if (vovel == "A" || vovel == "E" || vovel == "I" || vovel == "O" || vovel == "U"|| vovel == "e" || vovel == "i" || vovel == "o" || vovel == "u" || vovel == "u") {
            dialogueTrigger.TriggerDialogue("You Found an " + item.itemName);
        } else {
            dialogueTrigger.TriggerDialogue("You Found a " + item.itemName);
        }
        inventory.Items.Add(item);
    }
    public bool CheckItem(Item item) {
        if (inventory.Items.Contains(item)) {
            return true;
        } else {
            return false;
        }
    }
    public void Remove(Item item) {
        dialogueTrigger.TriggerDialogue("You Use A " + item.itemName);
        inventory.Items.Remove(item);
    }

    public void ListItems() {
        foreach (Transform item in ItemContent) {
            Destroy(item.gameObject);
        }

        foreach (var item in inventory.Items) {
            try {
                GameObject gameObject = Instantiate(InventoryItem, ItemContent);
                var itemName = gameObject.transform.Find("ItemName").GetComponent<TMP_Text>();
                var itemIcon = gameObject.transform.Find("ItemIcon").GetComponent<Image>();

                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;
            } catch (NullReferenceException) {
                return;
            }
        }
    }

    private void Awake(){
        if (manager == null)
        {
            manager = this;
        }
        dialogueTrigger = FindFirstObjectByType<DialogueTrigger>();
    }
    private void FixedUpdate() {
        ListItems();
    }
}
