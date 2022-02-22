using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShot : MonoBehaviour
{
    turretShooting AI;
    public float moveSpeed;
    float damage;

    void Start()
    {
        AI = GetComponentInParent<turretShooting>();
    }

    void FixedUpdate()
    {
        //move shot to target
        transform.position = Vector2.MoveTowards(transform.position, AI.goTo.position, moveSpeed);
        if(transform.position == AI.goTo.position)
        {
            damage = AI.damage;
            AI.goTo.gameObject.GetComponent<unitAI>().health -= damage;
            Debug.Log("deal damage to " + AI.goTo.name + "\n" + "base dmg " + AI.damage + " dealt dmg " + damage);
            Destroy(gameObject);
        }
        
    }
}
