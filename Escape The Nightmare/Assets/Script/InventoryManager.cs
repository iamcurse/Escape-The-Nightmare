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

    public void Add(Item item) {
        dialogueTrigger.TriggerDialogue("You Found A " + item.itemName);
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
    private void Update() {
        ListItems();
    }
}
