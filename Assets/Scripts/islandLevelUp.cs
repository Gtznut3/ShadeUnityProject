using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class islandLevelUp : MonoBehaviour
{
    //[SerializeField] private Vector3 islandPosition;
    Vector3 position = new Vector3(0, 1.5f, 400);

    [SerializeField] GameObject buttonUpgradeObject;

    public GameObject islandLevel1;
    public GameObject islandLevel2;
    public GameObject islandLevel3;
    public GameObject islandLevel4;
    public GameObject islandLevel5;

    [SerializeField] private int islandLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void Upgrade()
    {
        if (islandLevel == 0)
        {
            islandLevel += 1;
            Instantiate(islandLevel2, position, Quaternion.identity);
        }
        else if (islandLevel == 1)
        {
            islandLevel += 1;
            position.x -= 50;
            Instantiate(islandLevel3, position, Quaternion.identity);
        }
        else if (islandLevel == 2)
        {
            islandLevel += 1;
            position.x -= 200;
            Instantiate(islandLevel4, position, Quaternion.identity);
        }
        else if (islandLevel == 3)
        {
            islandLevel4.SetActive(false);
            islandLevel += 1;
            position.x -= 100;
            Instantiate(islandLevel5, position, Quaternion.identity);
        }
    }

    public int GetIslandLevel()
    {
        return islandLevel;
    }
}