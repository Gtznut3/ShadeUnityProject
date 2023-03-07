using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    GameObject[] allObjects;
    GameObject canvasPause;

    bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        canvasPause = GameObject.Find("PauseMenuCanvas");
        canvasPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        allObjects = FindObjectsOfType<GameObject>();
        isPause = !isPause;

        PauseAction();
        ShowPauseMenu();
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
