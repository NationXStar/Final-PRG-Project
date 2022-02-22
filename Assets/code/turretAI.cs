using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretAI : MonoBehaviour
{
    public float health;

    //rework turret code fully
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
