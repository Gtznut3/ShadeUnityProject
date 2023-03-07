using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryCoinsDisplay : MonoBehaviour
{
    private Text inventoryCoins;

    // Start is called before the first frame update
    void Start()
    {
        inventoryCoins = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTextValue(string value)
    {
        inventoryCoins.text = value;
    }
}
