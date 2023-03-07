using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuButtonScript : MonoBehaviour
{
    GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Start is called before the first frame update
    public void Resume()
    {
        gameManager.GetComponent<PauseScript>().Pause();
    }

    public void Settings()
    {
        // Et non, pas de settings, c'était une blague
    }

    public void Quit()
    {
        Application.Quit();        
    }
}
