using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitShootRange : MonoBehaviour
{
    GameObject goTo;
    unitAI AI;
    float oldMoveSpeed;
    void Start()
    {
        AI = GetComponentInParent<unitAI>();
        //save the unit move speed so it can be added back later
        oldMoveSpeed = AI.moveSpeed;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        goTo = GetComponentInParent<unitAI>().goTo.gameObject;
        //if the colided gameObject is the same as the target object
        //stop moving and start shooting
        if(col.gameObject == goTo.gameObject)
        {
            AI.moveSpeed = 0;
            AI.shoot = true;
            StartCoroutine(AI.shooting());
        }
    }

    //if coliding stops add back move speed and stop shooting
    void OnTriggerExit2D(Collider2D col)
    {
        AI.moveSpeed = oldMoveSpeed;
        AI.shoot = false;
    }
}
