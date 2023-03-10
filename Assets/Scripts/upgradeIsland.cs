using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class upgradeIsland : MonoBehaviour
{

    [SerializeField] GameObject buttonUpgradeObject;

    islandLevelUp levelUp;
    InventoryRessourcesManagementScript inventoryItems;

    private GameObject playerIsland;
    private GameObject ship;

    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");

        inventoryItems = ship.GetComponent<InventoryRessourcesManagementScript>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnClick()
    {
        playerIsland = GameObject.FindGameObjectWithTag("UpgradeZone");

        levelUp = playerIsland.GetComponent<islandLevelUp>();

        if (playerIsland != null)
        {
            if (levelUp.GetIslandLevel() == 0 && inventoryItems.GetCoin() >= 20 && inventoryItems.GetWood() >= 10 && inventoryItems.GetRock() >= 10)
            {
                inventoryItems.UseCoins(20);
                inventoryItems.UseWood(10);
                inventoryItems.UseRocks(10);
                UpgradeIsland();
            }
            else if (levelUp.GetIslandLevel() == 1 && inventoryItems.GetCoin() >= 50 && inventoryItems.GetWood() >= 20 && inventoryItems.GetRock() >= 20)
            {   
                inventoryItems.UseCoins(50);
                inventoryItems.UseWood(20);
                inventoryItems.UseRocks(20);
                UpgradeIsland();
            }
            else if (levelUp.GetIslandLevel() == 2 && inventoryItems.GetCoin() >= 100 && inventoryItems.GetWood() >= 50 && inventoryItems.GetRock() >= 50)
            {
                inventoryItems.UseCoins(100);
                inventoryItems.UseWood(50);
                inventoryItems.UseRocks(50);
                UpgradeIsland();
            }
            else if (levelUp.GetIslandLevel() == 3 && inventoryItems.GetCoin() >= 200 && inventoryItems.GetWood() >= 100 && inventoryItems.GetRock() >= 100)
            {
                inventoryItems.UseCoins(200);
                inventoryItems.UseWood(100);
                inventoryItems.UseRocks(100);
                buttonUpgradeObject.SetActive(false);
                UpgradeIsland();
            }
        }
    }

    private void UpgradeIsland()
    {
        levelUp.Upgrade();
        levelUp.gameObject.SetActive(false);
        levelUp.transform.parent.gameObject.SetActive(false);
    }
}
