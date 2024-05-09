using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class NT_PlayerStats : MonoBehaviour
{
    public int level;   //might get removed
    public int maxHp;
    public int currentHp;
    public float attackMult; //Multiplier for damage of attacks
    public float speedMult; //Multiplier for movement speed / acceleration
    public int dashNum;
    public int jumpNum;
    public int Armor; //% decrease to physical attacks damage
    public int Fortitude; //% decrease to status effect damage
    public List<string> inventory = new List<string>();
    public GameObject[] weaponSlots = new GameObject[2];
    public GameObject defaultMelee;
    public GameObject defaultRanged;

    void Start() 
    {
        level = 1;
        maxHp = 100;
        currentHp = 100;
        attackMult = 1;
        speedMult = 1;
        dashNum = 1;
        jumpNum = 1;
        Armor = 0;
        Fortitude = 0;
        inventory.Clear();
        weaponSlots[0] = defaultMelee;
        weaponSlots[1] = defaultRanged;
}

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

    public void AddItem(int maxHpAdd, int currentHpAdd, float attackMultAdd, float speedMultAdd, int dashNumAdd, int jumpNumAdd, int ArmorAdd, int FortitudeAdd)
    {
        maxHp += maxHpAdd;
        currentHp += currentHpAdd;
        attackMult += attackMultAdd;
        speedMult += speedMultAdd;
        dashNum += dashNumAdd;
        jumpNum += jumpNumAdd;
        Armor += ArmorAdd;
        Fortitude += FortitudeAdd;

        //print(maxHp);
    }

    public void EquipWeapon(int weaponSlot, GameObject weapon, Vector2 position)
    {
        weaponSlots[weaponSlot].gameObject.transform.position = position;
        weaponSlots[weaponSlot].gameObject.SetActive(true);
        weaponSlots[0] = weapon;
        weaponSlots[1] = weapon;
    }
}
