using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NT_Item : MonoBehaviour
{
    public string[] itemArray = new string[] { "item1", "item2", "item3", "item3"};
    public GameObject item;

    void Start()
    {
        item = GetComponent<GameObject>();
        string itemName = itemArray[Random.Range(0, itemArray.Length)];
        print(itemName);
    }
    
    //set item sprite to match name from array, then remove from array
    //(depending on whether we want items to be repeat pickups ala Risk of Rain, or pickups lke Isaac)
}
