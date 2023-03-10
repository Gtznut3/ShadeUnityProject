using System;
using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseScript : Singleton<PauseScript>
{
    GameObject[] allObjects;
    GameObject canvasPause;

    bool isPause = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        canvasPause = GameObject.Find("PauseMenuCanvas");
        if (canvasPause != null) canvasPause.SetActive(false);


        EventManager.Instance.OnMap += Pause;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            ShowPauseMenu();
        }
    }

    public void Pause()
    {
        allObjects = FindObjectsOfType<GameObject>();
        isPause = !isPause;

        PauseAction();
    }

    void PauseAction()
    {
        foreach (GameObject obj in allObjects)
        {
            if (obj.GetComponent<AbleToPause>() != null)
            {
                AbleToPause[] list = obj.GetComponents<AbleToPause>();
                foreach (AbleToPause ableToPauseScript in list)
                {
                    if (isPause) ableToPauseScript.Pause();
                    else ableToPauseScript.Continue();
                }
            }
        }
    }

    void ShowPauseMenu()
    {
        if (isPause) canvasPause.SetActive(true);
        else canvasPause.SetActive(false);
    }
}
