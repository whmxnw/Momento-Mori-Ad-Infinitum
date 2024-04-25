using UnityEngine;
using UnityEngine.UIElements;

public class NT_WeaponItem : MonoBehaviour
{
    NT_PlayerStats playerStats;
    public string itemName;
    public int damage;
    public float recoverySpeed;
    public string weaponType;
    NT_WeaponController weaponController;
    float floatSpeed = 1f;
    float floatHeight = .25f;
    private Vector3 startPos;

    public bool isHovering;
    float pickupDistance = 2f;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<NT_PlayerStats>();
        weaponController = player.GetComponentInChildren<NT_WeaponController>();
        startPos = transform.position;
    }

    private void Update()
    {
        Vector3 newPos = startPos + Vector3.up * Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = newPos;

        if (isHovering && Input.GetKeyDown(KeyCode.E) && IsPlayerInRange())
        {
            PickUpWeapon();
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

    private void PickUpWeapon()
    {
        print("picked up " + itemName);
        playerStats.EquipWeapon(weaponController.whichWeaponSlot, this.gameObject, transform.position);
        this.gameObject.SetActive(false);
    }

    private bool IsPlayerInRange()
    {
        float distance = Vector3.Distance(transform.position, playerStats.transform.position);
        return distance <= pickupDistance;
    }
}
