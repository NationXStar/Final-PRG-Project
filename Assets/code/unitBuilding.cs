using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitBuilding : MonoBehaviour
{
    public GameObject unit1Go, unit2Go;
    public int unit1Price, unit2Price;
    public float unit1QueueUpTime, unit2QueueUpTime;
    public bool isEnemy;
    string whichTeam;
    buyUnit[] buyScripts;

    void Start()
    {
        buyScripts = GetComponentsInChildren<buyUnit>();
        //check to see what team the unit spawned from the building will be
        if(isEnemy)
        {
            whichTeam = "enemy";
        }
        else
        {
            whichTeam = "player";
        }
    }
    //functions that can be activated through buttons to do the unit buyying
    public void buyUnit1()
    {
        buyScripts[0].buy(unit1Go, unit1Price, unit1QueueUpTime, whichTeam);
    }

    public void buyUnit2()
    {
        buyScripts[1].buy(unit2Go, unit2Price, unit2QueueUpTime, whichTeam);
    }
}