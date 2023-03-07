using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryRessourcesManagementScript : MonoBehaviour
{
    private int coins, woods, rocks;

    private GameObject inventory;

    private inventoryCoinsDisplay numberOfCoins;
    private inventoryWoodDisplay numberOfWoods;
    private inventoryRockDisplay numberOfRocks;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");

        numberOfCoins = inventory.GetComponentInChildren<inventoryCoinsDisplay>();
        numberOfWoods = inventory.GetComponentInChildren<inventoryWoodDisplay>();
        numberOfRocks = inventory.GetComponentInChildren<inventoryRockDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddInventoryCoins(int value)
    {
        coins += value;
        Debug.Log("you get " + coins + " Coins");
        setInventoryCoins();
    }

    public void AddInventoryWood(int value)
    {
        woods += value;
        Debug.Log("you get " + woods + " Woods");
        setInventoryWood();
    }

    public void AddInventoryRock(int value)
    {
        rocks += value;
        Debug.Log("you get " + rocks + " Rocks");
        setInventoryRock();
    }

    public void setInventoryCoins()
    {
        numberOfCoins.setTextValue(coins.ToString());
    }

    public void setInventoryWood()
    {
        numberOfWoods.setTextValue(woods.ToString());
    }

    public void setInventoryRock()
    {
        numberOfRocks.setTextValue(rocks.ToString());
    }
}
