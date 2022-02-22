using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShooting : MonoBehaviour
{
    public GameObject shot;
    bool shoot;
    public float fireRate;
    public float damage;
    public Transform goTo;
    public bool isPlayer;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(!(col.tag == "turret"))
        {
            if(isPlayer)
            {
                if(col.tag == "player")
                {
                    return;
                }
            }
            else
            {
                if(col.tag == "enemy")
                {
                    return;
                }
            }
            goTo = col.transform;
            Debug.Log(goTo);
            shoot = true;
            StartCoroutine(shooting());
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        shoot = false;
    }

    public IEnumerator shooting()
    {
        while(shoot)
        {
            yield return new WaitForSeconds(fireRate);
            //Instantiate(shot, transform);
        }
    }
}
