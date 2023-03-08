using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ressourcesScript : MonoBehaviour
{
    [SerializeField] protected float numberMax;
    [SerializeField] protected float number;
    [SerializeField] protected float timeNumberMax;

    // Start is called before the first frame update
    virtual public void Start()
    {
        
    }

    // Update is called once per frame
    virtual public void Update()
    {

    }

    public void Get()
    {
        Debug.Log("you get " + (int)number + " ");
        number -= (int)number;
    }

    public void Add(float coin)
    {
        if (number + coin > numberMax) number = numberMax;
        else number += coin;
    }

    public float GetMax()
    {
        return numberMax;
    }

    public int GetNumber()
    {
        return (int)number;
    }
}