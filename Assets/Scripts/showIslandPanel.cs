using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showIslandPanel : MonoBehaviour
{
    // Ressources
    [SerializeField] GameObject islandObject;
    CanvasGroup islandCanvasGroup;

    [SerializeField] GameObject buttonIslandObject;
    CanvasGroup buttonIslandGroup;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "DockageRessources")
        {
            buttonIslandGroup.alpha = 1f;
            islandCanvasGroup.alpha = 1f;
            buttonIslandGroup.interactable = true;
        }
        else if (other.gameObject.tag == "EventZoneRessources")
        {
            islandCanvasGroup.alpha = 1f;
            buttonIslandGroup.alpha = 0f;
            buttonIslandGroup.interactable = false;

            islandObject.SetActive(true);
        }
        else if (other.gameObject.tag == "DockageCivilisation")
        {
            islandCanvasGroup.alpha = 1f;
            buttonIslandGroup.alpha = 1f;
            buttonIslandGroup.interactable = true;
        }
        else if (other.gameObject.tag == "EventZoneCivilisation")
        {
            islandCanvasGroup.alpha = 1f;
            buttonIslandGroup.alpha = 0f;
            buttonIslandGroup.interactable = false;

            islandObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "DockageRessources")
        {
            buttonIslandGroup.alpha = 0f;
            buttonIslandGroup.interactable = false;

            islandCanvasGroup.alpha = 1f;
        }
        else if (other.tag == "EventZoneRessources")
        {
            islandCanvasGroup.alpha = 0f;
            islandObject.SetActive(false);
        }
        else if (other.gameObject.tag == "DockageCivilisation")
        {
            buttonIslandGroup.alpha = 0f;
            buttonIslandGroup.interactable = false;

            islandCanvasGroup.alpha = 1f;
        }
        else if (other.gameObject.tag == "EventZoneCivilisation")
        {
            islandCanvasGroup.alpha = 0f;
            islandObject.SetActive(false);
        }
        else if (other.gameObject.tag == "DockageBuild")
        {
        }
        else if (other.gameObject.tag == "EventZoneBuild")
        {
        }
    }

    void Start()
    {
        islandCanvasGroup = islandObject.GetComponent<CanvasGroup>();
        buttonIslandGroup = buttonIslandObject.GetComponent<CanvasGroup>();
        buttonIslandGroup.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
