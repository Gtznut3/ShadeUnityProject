using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryWoodDisplay : MonoBehaviour
{
    private Text inventoryWoods;

    // Start is called before the first frame update
    void Start()
    {
        inventoryWoods = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTextValue(string value)
    {
        inventoryWoods.text = value;
    }
}
