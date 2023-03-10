using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeposeHumans : MonoBehaviour, AbleToPause
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

    InventoryRessourcesManagementScript inventoryItems;

    HumanOnIslandScript humanOnIsland;

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
        islandObject = GameObject.Find(nameIsland);

        humanOnIsland = islandObject.GetComponent<HumanOnIslandScript>();


        if (!isPause && humanOnIsland.GetSlaveMax() != humanOnIsland.GetSlave())
        {
            if (humanOnIsland.GetSlaveMax() - humanOnIsland.GetSlave() < inventoryItems.GetSlave())
            {
                inventoryItems.UseHuman(humanOnIsland.GetSlaveMax() - humanOnIsland.GetSlave());
                humanOnIsland.AddHuman(humanOnIsland.GetSlaveMax() - humanOnIsland.GetSlave());
            }
            else
            {
                humanOnIsland.AddHuman(inventoryItems.GetSlave());
                inventoryItems.UseHuman(inventoryItems.GetSlave());
            }
        }
    }


    public void SetIslandObject(string islandString)
    {
        nameIsland = islandString;
        islandObject = GameObject.Find(nameIsland);
    }
}
