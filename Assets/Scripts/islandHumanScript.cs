using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class islandHumanScript : ressourcesScript
{
    ChangeIcon changeIconScript;

    // Start is called before the first frame update
    override public void Awake()
    {
        number = numberMax;

        changeIconScript = GetComponentInChildren<ChangeIcon>();
    }

    // Update is called once per frame
    override public void Update()
    {
        if (number == 0)
        {
            changeIconScript.DisableIcon();
        }
    }
}
