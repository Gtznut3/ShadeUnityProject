using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateTextScript : MonoBehaviour
{
    // Permet de modifier n'importe quel text quand il est en component :D

    [SerializeField] private Text text;
    private string textValue;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string getTextValue()
    {
        return textValue;
    }

    public void setTextValue(string value)
    {
        textValue = value;
        text.text = value;
    }

    public Text getText()
    {
        return text;
    }
}
