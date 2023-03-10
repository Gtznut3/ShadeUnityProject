using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeIcon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableIcon()
    {
        gameObject.SetActive(false);
    }
    public void EnableIcon()
    {
        gameObject.SetActive(true);
    }

    public void ChangeIconTexture(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }
}
