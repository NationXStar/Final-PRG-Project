using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class townHall : MonoBehaviour
{
    public float health;
    public float waitTime;
    public int amountGiven;
    currency gold;
    public bool isPlayer;

    void Start()
    {
        if(isPlayer)
        {
            gold = GameObject.Find("goldAmount").GetComponent<currency>();
            StartCoroutine(giveGold());
        }
        else
        {
            gameObject.AddComponent<enemyAI>();
        }
    }
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator giveGold()
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            gold.gold += amountGiven;
            Debug.Log("give gold");
        }
    }

    
}
