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
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake(){
        Instance = this;
    }

    public void Add(Item item) {
        Items.Add(item);
        ListItems();
    }
    public bool CheckItem(Item item) {
        if (Items.Contains(item)) {
            return true;
        } else {
            return false;
        }
    }
    public void Remove(Item item) {
        Items.Remove(item);
        ListItems();
    }

    public void ListItems() {
        foreach (Transform item in ItemContent) {
            Destroy(item.gameObject);
        }

        foreach (var item in Items) {
            GameObject gameObject = Instantiate(InventoryItem, ItemContent);
            var itemName = gameObject.transform.Find("ItemName").GetComponent<TMP_Text>();
            var itemIcon = gameObject.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

        }
    }
}
