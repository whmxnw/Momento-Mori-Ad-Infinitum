using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DH_EnemyAttackController : MonoBehaviour
{
    public DH_EnemyController enemy;
    public int activeDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        int enemydirection = gameObject.transform.parent.GetComponent<DH_EnemyController>().direction;
        if (enemydirection == activeDirection)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            enemy.CollisionAttack(other.gameObject);
    }

    public void SwapActiveHitbox()
    {
        if (gameObject.activeSelf)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }


}
