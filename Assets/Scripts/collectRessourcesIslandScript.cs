using System;
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

    private islandCoinsScript islandCoins;
    private islandWoodScript islandWood;
    private islandRockScript islandRock;
    private islandHumanScript islandHuman;

    // Start is called before the first frame update
    void Start()
    {
        islandObject = GameObject.Find(nameIsland);
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

            if (islandCoins != null) islandCoins.Get();
            if (islandWood != null) islandWood.Get();
            if (islandRock != null) islandRock.Get();
            if (islandHuman != null)
            {
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
