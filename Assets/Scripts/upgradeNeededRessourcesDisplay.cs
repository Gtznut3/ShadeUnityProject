using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeNeededRessourcesDisplay : MonoBehaviour
{
    GameObject upgradeIsland;
    GameObject ship;
    islandLevelUp levelUp;

    InventoryRessourcesManagementScript inventoryRessources;

    [SerializeField] private GameObject coinsUpdateText;
    updateTextScript coinUpgrade;
    [SerializeField] private GameObject woodUpdateText;
    updateTextScript woodUpgrade;
    [SerializeField] private GameObject rockUpdateText;
    updateTextScript rockUpgrade;


    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
        inventoryRessources = ship.GetComponent<InventoryRessourcesManagementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        upgradeIsland = GameObject.FindGameObjectWithTag("UpgradeZone");
        levelUp = upgradeIsland.GetComponent<islandLevelUp>();

        if (upgradeIsland != null)
        {
            coinUpgrade = coinsUpdateText.GetComponent<updateTextScript>();
            woodUpgrade = woodUpdateText.GetComponent<updateTextScript>();
            rockUpgrade = rockUpdateText.GetComponent<updateTextScript>();

            if (levelUp.GetIslandLevel() == 0)
            {
                coinUpgrade.setTextValue("Coins : " + inventoryRessources.GetCoin().ToString() + "/" + "20");
                woodUpgrade.setTextValue("Wood : " + inventoryRessources.GetWood().ToString() + "/" + "10");
                rockUpgrade.setTextValue("Rocks : " + inventoryRessources.GetRock().ToString() + "/" + "10");
            }
            else if (levelUp.GetIslandLevel() == 1)
            {
                coinUpgrade.setTextValue("Coins : " + inventoryRessources.GetCoin().ToString() + "/" + "50");
                woodUpgrade.setTextValue("Wood : " + inventoryRessources.GetWood().ToString() + "/" + "20");
                rockUpgrade.setTextValue("Rocks : " + inventoryRessources.GetRock().ToString() + "/" + "20");
            }
            else if (levelUp.GetIslandLevel() == 2)
            {
                coinUpgrade.setTextValue("Coins : " + inventoryRessources.GetCoin().ToString() + "/" + "100");
                woodUpgrade.setTextValue("Wood : " + inventoryRessources.GetWood().ToString() + "/" + "50");
                rockUpgrade.setTextValue("Rocks : " + inventoryRessources.GetRock().ToString() + "/" + "50");
            }
            else if (levelUp.GetIslandLevel() == 3)
            {
                coinUpgrade.setTextValue("Coins : " + inventoryRessources.GetCoin().ToString() + "/" + "200");
                woodUpgrade.setTextValue("Wood : " + inventoryRessources.GetWood().ToString() + "/" + "100");
                rockUpgrade.setTextValue("Rocks : " + inventoryRessources.GetRock().ToString() + "/" + "100");
            }
        }
    }
}
