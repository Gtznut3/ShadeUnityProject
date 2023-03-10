using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanOnIslandScript : MonoBehaviour
{
    [SerializeField] protected int humanOnIsland;
    [SerializeField] protected int humanMaxOnIsland;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHuman(int slave)
    {
        if (humanOnIsland + slave > humanMaxOnIsland) humanOnIsland = humanMaxOnIsland;
        else humanOnIsland += slave;
    }

    public int GetSlave()
    {
        return humanOnIsland;
    }

    public int GetSlaveMax()
    {
        return humanMaxOnIsland;
    }
}
