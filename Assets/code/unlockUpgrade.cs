using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unlockUpgrade : MonoBehaviour
{
    public bool upgradeUnit; //false = unit1 true = unit2
    public bool isNonUnitBuildng; //false = unit building true = non unit buildings aka Townhall and Turrets
    public int price;
    public GameObject building;
    currency playerCurrency;
    Button button;
    void Start()
    {
        playerCurrency = GameObject.Find("goldAmount").GetComponent<currency>();
        button = GetComponent<Button>();
    }
    public void buyUpgrade()
    {
        if(price > playerCurrency.gold)
        {
            Debug.Log("Cant buy upgrade");
            return;
        }
        playerCurrency.gold -= price;
        button.onClick.RemoveAllListeners();
        if(isNonUnitBuildng)
        {
            //button.onClick.AddListener() will be to upgrade buildings later
        }
        else
        {
            if(upgradeUnit)
            {
                button.onClick.AddListener(building.GetComponent<unitBuilding>().buyUnit2);
                //button.colors.normalColor = new Color(1, 1, 1, 1);
            }           
            else
            {
                button.onClick.AddListener(building.GetComponent<unitBuilding>().buyUnit1);
            }
        }        
    }
}
