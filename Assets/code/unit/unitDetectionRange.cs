using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitDetectionRange : MonoBehaviour
{
    unitAI AI;

    void Start()
    {
        AI = GetComponentInParent<unitAI>();
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<CircleCollider2D>())
        {
            return;
        }
        if(!(col.gameObject.tag == AI.tag))
        {
            if(AI.goTo.tag == "turret" && !(col.tag == "turret" || col.tag == "townhall"))
            {
                AI.goTo = col.transform;
            }
        }
    }
}
