using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
/*    public GameObject NewGameButton;
    public GameObject LoadGameButton;
    public string LoadMenu;*/
    public string NameSceneLvl;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene(NameSceneLvl);
    }
    public void OpenOption()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
