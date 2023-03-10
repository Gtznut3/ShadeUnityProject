using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanOnIslandScript : MonoBehaviour
{
    [SerializeField] protected int humanOnIsland;
    [SerializeField] protected int humanMaxOnIsland;

    ChangeIcon changeIconScript;

    Sprite spriteIconWithWorker;

    // Start is called before the first frame update
    void Start()
    {
        changeIconScript = GetComponentInChildren<ChangeIcon>();

        spriteIconWithWorker = Resources.Load<Sprite>("Images/ressources_icon_worker");
    }

    // Update is called once per frame
    void Update()
    {
        if (humanOnIsland != 0)
        {
            changeIconScript.ChangeIconTexture(spriteIconWithWorker);
        }
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
