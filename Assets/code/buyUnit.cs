using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyUnit : MonoBehaviour
{
    currency playerCurrency;
    int currentQueueUp;
    void Start()
    {
        playerCurrency = GameObject.Find("goldAmount").GetComponent<currency>();
    }
    //reusable function that can be used for every unit buy
    public void buy(GameObject unit, int price, float QueueUpTime, string whichTeam)
    {
        if(whichTeam == "player")
        {
            //check if the player has enough of the currency to buy the unit
            if(price > playerCurrency.gold)
            {
                Debug.Log("cant buy " + unit);
                return;
            }
            //remove the untiy price from the players bank
            playerCurrency.gold -= price;
        }
        //check the there is an active queue up'
        //if there isn't start coroutine for unit spawning
        //if there is add 1 to the unity spawning
        if(currentQueueUp == 0)
        {
            currentQueueUp++;
            StartCoroutine(QueueUp(unit, QueueUpTime, whichTeam));
        }
        else
        {
            currentQueueUp++;
        }
    }

    IEnumerator QueueUp(GameObject unit, float waitTime, string whichTeam)
    {
        for(int i = 0; i < currentQueueUp; i++)
        {
            yield return new WaitForSeconds(waitTime);
            GameObject Go = Instantiate(unit);
            //set spawn location to building
            Go.transform.position = transform.position;
            Go.tag = whichTeam;
            //set its name so it doesn't have clone behind of it
            Go.name = unit.name;
            Debug.Log("Spawn " + unit);
        }
        currentQueueUp = 0;
    }
}