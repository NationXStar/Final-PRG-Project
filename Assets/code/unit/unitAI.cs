using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitAI : MonoBehaviour
{
    public float health, damage, moveSpeed, fireRate, detectionSize, shootSize;
    public Transform goTo;
    public GameObject shot;
    public bool shoot;
    CircleCollider2D detectionRange, shootRange;
    Transform[] turrets;

    //AI works by looking for the first turret to be destroyed and if there are no turrets left
    //it goes for the townhall
    //there is a detection range around the player that if it colides with an enemy it will set its target
    //to that

    void Start()
    {
        findTurrets();
        shootRange = transform.GetChild(0).GetComponent<CircleCollider2D>();
        detectionRange = transform.GetChild(1).GetComponent<CircleCollider2D>();
        shootRange.radius = shootSize;
        detectionRange.radius = detectionSize;
    }
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        //if the object it was going to is destroyed it will return null
        //when this happens check for a new thing to find which will be a turret
        if(goTo == null)
        {
            findTurrets();
            return;
        }
        //move unit to the target
        transform.position = Vector2.MoveTowards(transform.position, goTo.position, moveSpeed);
    }

    void findTurrets()
    {
        if(tag == "player")
        {
            turrets = GameObject.Find("enemyTurrets").GetComponentsInChildren<Transform>();
        }
        else
        {
            turrets = GameObject.Find("playerTurrets").GetComponentsInChildren<Transform>();
        }
        //this will return 1 extra aka the parent so always do +1 when doing things
        //do try catch
        //if it catches it means all turrets are destroyed
        try
        {
            goTo = turrets[1];
            return;
        }
        catch
        {
            Debug.Log("No turrets \n go to townhall");
        }
        if(tag == "player")
        {
            goTo = GameObject.Find("enemyBuildings").transform.GetChild(0);
        }
        else
        {
            goTo = GameObject.Find("playerBuildings").transform.GetChild(0);
        }
    }

    //this coroutine does the shooting by waiting for the firerate in seconds then spawning
    //a gameObject called shot
    public IEnumerator shooting()
    {
        while(shoot)
        {
            yield return new WaitForSeconds(fireRate);
            Instantiate(shot, transform);
        }
    }
}
