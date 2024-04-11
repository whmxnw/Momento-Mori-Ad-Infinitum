using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class NT_PlayerStats : MonoBehaviour
{
    public int level = 1;   //might get removed
    public int maxHp = 100;
    public int currentHp = 100;
    public float attackMult = 1; //Multiplier for damage of attacks
    public float speedMult = 1; //Multiplier for movement speed / acceleration
    public int dashNum = 1;
    public int jumpNum = 1;
    public int Armor = 0; //% decrease to physical attacks damage
    public int Fortitude = 0; //% decrease to status effect damage
    public List<string> inventory = new List<string>();

    void Update()
    {
        if(currentHp > maxHp) { currentHp = maxHp; }    //making sure player health doesn't overflow
        if(currentHp <= 0)
        {
            //replace with death script
            print("player died");
        }
    }

    void levelUp()  //level up thing if we end up implementing levels
    {
        level++;
        maxHp += 5;
        currentHp += 5;
        attackMult += .05f;
        Armor += 2;
        Fortitude += 2;
    }

    public void AddItemToInventory(string itemName)
    {
        inventory.Add(itemName);
    }

    public void ModifyStats(string statName, int changeAmount)
    {



        switch (statName)
        {
            case "maxHp":
                maxHp += changeAmount;
                break;
            case "currentHp":
                currentHp += changeAmount;
                break;
            case "attackMult":
                attackMult += changeAmount;
                break;
            case "speedMult":
                speedMult += changeAmount;
                break;
            case "dashNum":
                dashNum += changeAmount;
                break;
            case "jumpNum":
                jumpNum += changeAmount;
                break;
            case "Armor":
                Armor += changeAmount;
                break;
            case "Fortitude":
                Fortitude += changeAmount;
                break;
            default:
                break;
        }
    }
}
