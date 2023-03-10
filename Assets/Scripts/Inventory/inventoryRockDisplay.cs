using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryRockDisplay : MonoBehaviour
{
     private Text inventoryRocks;

    // Start is called before the first frame update
    void Start()
    {
        inventoryRocks = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTextValue(string value)
    {
        inventoryRocks.text = value;
    }
}
