using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Create Item Database")]
public class NT_ItemDatabase : ScriptableObject
{
    public List<NT_Item.ItemData> items = new List<NT_Item.ItemData>(); 
}
