using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NT_ItemDatabase))]
public class NT_ItemDatabaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        NT_ItemDatabase itemDatabase = (NT_ItemDatabase)target;
        if (GUILayout.Button("Add Item"))
        {
            itemDatabase.items.Add(new NT_Item.ItemData());
        }

        for (int i = 0; i < itemDatabase.items.Count; i++)
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            GUILayout.Label("Item " + (i + 1), EditorStyles.boldLabel);
            itemDatabase.items[i].itemName = EditorGUILayout.TextField("Item Name", itemDatabase.items[i].itemName);

            // Display each stat change with editable fields
            foreach (var statChange in itemDatabase.items[i].statChanges.Keys)
            {
                itemDatabase.items[i].statChanges[statChange] = EditorGUILayout.IntField(statChange, itemDatabase.items[i].statChanges[statChange]);
            }

            EditorGUILayout.EndVertical();
        }

        EditorUtility.SetDirty(target);
    }
}