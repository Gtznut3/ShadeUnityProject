using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class islandCoinsScript : ressourcesScript, AbleToPause
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

    // Start is called before the first frame update
    override public void Awake()
    {
    }

    // Update is called once per frame
    override public void Update()
    {
        timeNumberMax = baseTimeNumberMax * (humanMaxOnIsland + 1 - humanOnIsland) / 10f;
        if (!isPause)
        {
            float coinsGet = numberMax * Time.deltaTime / timeNumberMax;
            if (number < numberMax) Add(coinsGet);
        }
    }
}
