using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryRessourcesManagementScript : MonoBehaviour
{
    [SerializeField] private int coins, woods, rocks, humans;

    private GameObject inventory;

    private inventoryCoinsDisplay numberOfCoins;
    private inventoryWoodDisplay numberOfWoods;
    private inventoryRockDisplay numberOfRocks;
    private updateTextScript numberOfHuman;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");

        numberOfCoins = inventory.GetComponentInChildren<inventoryCoinsDisplay>();
        numberOfWoods = inventory.GetComponentInChildren<inventoryWoodDisplay>();
        numberOfRocks = inventory.GetComponentInChildren<inventoryRockDisplay>();
        numberOfHuman = inventory.GetComponentInChildren<updateTextScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddInventoryCoins(int value)
    {
        coins += value;
        numberOfCoins.setTextValue(coins.ToString());
    }

    public void AddInventoryWood(int value)
    {
        woods += value;
        numberOfWoods.setTextValue(woods.ToString());
    }

    public void AddInventoryRock(int value)
    {
        rocks += value;
        numberOfRocks.setTextValue(rocks.ToString());
    }

    public void AddInventoryHuman(int value)
    {
        humans += value;
        numberOfHuman.setTextValue(humans.ToString());
    }

    public void UseCoins(int value)
    {
        coins -= value;
        numberOfCoins.setTextValue(coins.ToString());
    }

    public void UseWood(int value)
    {
        woods -= value;
        numberOfWoods.setTextValue(woods.ToString());
    }

    public void UseRocks(int value)
    {
        rocks -= value;
        numberOfRocks.setTextValue(rocks.ToString());
    }

    public void UseHuman(int value)
    {
        Debug.Log(value);
        humans -= value;
        numberOfHuman.setTextValue(humans.ToString());
    }

    public int GetCoin()
    {
        return coins;
    }

    public int GetWood()
    {
        return woods;
    }

    public int GetRock()
    {
        return rocks;
    }

    public int GetSlave()
    {
        return humans;
    }
}
