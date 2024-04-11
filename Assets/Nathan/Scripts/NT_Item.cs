using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NT_Item : MonoBehaviour
{
    public NT_PlayerStats player;
    public string itemName;
    public Dictionary<string, int> statChanges = new Dictionary<string, int>();

    public bool isHovering = false;

    [System.Serializable]
    public class ItemData
    {
        public string itemName;
        public Dictionary<string, int> statChanges = new Dictionary<string, int>();
    }

    public List<ItemData> itemDatabase;

    void Start()
    {
        if (itemDatabase.Count > 0)
        {
            // Get a random item from the item database
            ItemData randomItem = itemDatabase[Random.Range(0, itemDatabase.Count)];
            // Apply the item's name and stat changes to the item prefab
            ApplyItemData(randomItem);
        }
    }

    private void Update()
    {
        if (isHovering && Input.GetKeyDown(KeyCode.E)) 
        {
            PickUpItem();
        }
    }

    private void OnMouseEnter()
    {
        isHovering = true;
    }

    private void OnMouseExit()
    {
        isHovering = false;
    }

    private void PickUpItem()
    {
        print("pickup");
        foreach (KeyValuePair<string, int> statChange in statChanges)
        {
            player.ModifyStats(statChange.Key, statChange.Value);
        }
        player.AddItemToInventory(itemName);
        Destroy(gameObject);
    }

    private void ApplyItemData(ItemData itemData)
    {
        itemName = itemData.itemName;
        statChanges = itemData.statChanges;
    }
}
