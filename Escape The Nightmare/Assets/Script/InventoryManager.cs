using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using TMPro;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public Inventory inventory;

    public Transform ItemContent;
    public GameObject InventoryItem;

    private DialogueTrigger dialogueTrigger;

    private void Awake(){
        if (Instance == null)
        {
            Instance = this;
        }
        ListItems();
        dialogueTrigger = FindFirstObjectByType<DialogueTrigger>();
    }

    public void Add(Item item) {
        dialogueTrigger.TriggerDialogue("You Found A " + item.itemName);
        inventory.Items.Add(item);
        ListItems();
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
        ListItems();
    }

    public void ListItems() {
        foreach (Transform item in ItemContent) {
            Destroy(item.gameObject);
        }

        foreach (var item in inventory.Items) {
            GameObject gameObject = Instantiate(InventoryItem, ItemContent);
            var itemName = gameObject.transform.Find("ItemName").GetComponent<TMP_Text>();
            var itemIcon = gameObject.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

        }
    }
}
