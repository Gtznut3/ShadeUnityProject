using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showInventory : MonoBehaviour
{
    [SerializeField] CanvasGroup inventoryGroup;

    // Start is called before the first frame update
    void Start()
    {
        inventoryGroup = GameObject.Find("Inventory").GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.M)) 
        {
            if (inventoryGroup.alpha == 1f)
                inventoryGroup.alpha = 0f;
            else
                inventoryGroup.alpha = 1f;
        }
    }
}
