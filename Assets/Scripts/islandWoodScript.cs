using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class islandWoodScript : ressourcesScript, AbleToPause
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
    override public void Start()
    {
    }

    // Update is called once per frame
    override public void Update()
    {
        if (!isPause)
        {
            float woodGet = numberMax * Time.deltaTime / timeNumberMax;
            if (number < numberMax) Add(woodGet);
        }
    }
}
