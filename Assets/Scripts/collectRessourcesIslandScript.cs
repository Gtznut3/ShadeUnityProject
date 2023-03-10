using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectRessourcesIslandScript : MonoBehaviour, AbleToPause
{
    bool isPause = false;
    public void Continue()
    {
        isPause = false;
    }

    public void Pause()
    {
        isPause = true;
    }

    [SerializeField] private string nameIsland;

    private GameObject islandObject;
    private GameObject ship;

    private InventoryRessourcesManagementScript inventoryRessources;
    private islandCoinsScript islandCoins;
    private islandWoodScript islandWood;
    private islandRockScript islandRock;
    private islandHumanScript islandHuman;

    // Start is called before the first frame update
    void Start()
    {
        islandObject = GameObject.Find(nameIsland);
        ship = GameObject.FindGameObjectWithTag("Player");

        inventoryRessources = ship.GetComponent<InventoryRessourcesManagementScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (!isPause)
        {
            if (islandObject != null)
            {
                islandCoins = islandObject.GetComponent<islandCoinsScript>();
                islandWood = islandObject.GetComponent<islandWoodScript>();
                islandRock = islandObject.GetComponent<islandRockScript>();
                islandHuman = islandObject.GetComponent<islandHumanScript>();
            }

            if (islandCoins != null)
            {
                inventoryRessources.AddInventoryCoins(islandCoins.GetNumber());
                islandCoins.Get();
            }
            if (islandWood != null)
            {
                inventoryRessources.AddInventoryWood(islandWood.GetNumber());
                islandWood.Get();
            }
            if (islandRock != null)
            {
                inventoryRessources.AddInventoryRock(islandRock.GetNumber());
                islandRock.Get();
            }
            if (islandHuman != null)
            {
                inventoryRessources.AddInventoryHuman(islandHuman.GetNumber());
                islandHuman.Get();
            }
        }
    }

    public void SetIslandObject(string islandString)
    {
        nameIsland = islandString;
        islandObject = GameObject.Find(nameIsland);
    }
}
