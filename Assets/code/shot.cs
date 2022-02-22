using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    unitAI AI;
    public float moveSpeed;
    float damage;
    
    void Start()
    {
        AI = GetComponentInParent<unitAI>();
    }
    void FixedUpdate()
    {
        //move shot to target
        transform.position = Vector2.MoveTowards(transform.position, AI.goTo.position, moveSpeed);
        //if the shot position is the same as the target position
        if(transform.position == AI.goTo.position)
        {
            if(AI.goTo.name == "humvee" || AI.goTo.name == "tank" || AI.goTo.name == "helicopter" || AI.goTo.name == "fighterjet")
            {
                if(AI.name == "soldier" || AI.name == "humvee" || AI.name == "helicopter")
                {
                    damage = AI.damage * 0.5f;
                }
                else
                {
                    damage = AI.damage * 1.5f;
                }
                AI.goTo.gameObject.GetComponent<unitAI>().health -= damage;
            }
            else if(AI.goTo.name == "soldier" || AI.goTo.name == "rocketeer")
            {
                if(AI.name == "soldier" || AI.name == "humvee" || AI.name == "helicopter")
                {
                    damage = AI.damage * 1.5f;
                }
                else
                {
                    damage = AI.damage * 0.5f;
                }
                AI.goTo.gameObject.GetComponent<unitAI>().health -= damage;
            }
            else if(AI.goTo.name == "turret")
            {
                if(AI.name == "soldier" || AI.name == "humvee" || AI.name == "helicopter")
                {
                    damage = AI.damage * 0.5f;
                }
                else
                {
                    damage = AI.damage * 1.5f;
                }
                AI.goTo.gameObject.GetComponent<turretAI>().health -= damage;
            }
            else if(AI.goTo.name == "townHall")
            {
                if(AI.name == "soldier" || AI.name == "humvee" || AI.name == "helicopter")
                {
                    damage = AI.damage * 0.5f;
                }
                else
                {
                    damage = AI.damage * 1.5f;
                }
                AI.goTo.gameObject.GetComponent<townHall>().health -= damage;
            }
            Debug.Log("deal damage to " + AI.goTo.name + "\n" + "base dmg " + AI.damage + " dealt dmg " + damage);
            Destroy(gameObject);
        }
    }
}
