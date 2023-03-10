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

    [SerializeField] GameObject buttonUpgradeObject;
    CanvasGroup buttonUpgradeGroup;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "DockageRessources" || other.gameObject.tag == "DockageCivilisation")
        {
            islandCanvasGroup.alpha = 1f;
            buttonIslandGroup.alpha = 1f;
            buttonIslandGroup.interactable = true;
        }
        else if (other.gameObject.tag == "EventZoneRessources" || other.gameObject.tag == "EventZoneCivilisation")
        {
            islandCanvasGroup.alpha = 1f;
            buttonIslandGroup.alpha = 0f;
            buttonIslandGroup.interactable = false;

            islandObject.SetActive(true);
        }
        else if (other.gameObject.tag == "UpgradeZone")
        {
            buttonUpgradeGroup.alpha = 1f;
            buttonUpgradeGroup.interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "DockageRessources" || other.gameObject.tag == "DockageCivilisation")
        {
            buttonIslandGroup.alpha = 0f;
            buttonIslandGroup.interactable = false;

            islandCanvasGroup.alpha = 1f;
        }
        else if (other.tag == "EventZoneRessources" || other.gameObject.tag == "EventZoneCivilisation")
        {
            islandCanvasGroup.alpha = 0f;
            islandObject.SetActive(false);
        }
        else if (other.gameObject.tag == "UpgradeZone")
        {
            buttonUpgradeGroup.alpha = 0f;
            buttonUpgradeGroup.interactable = false;
        }
    }

    void Start()
    {
        islandCanvasGroup = islandObject.GetComponent<CanvasGroup>();
        buttonIslandGroup = buttonIslandObject.GetComponent<CanvasGroup>();
        buttonIslandGroup.interactable = false;
        
        buttonUpgradeGroup = buttonUpgradeObject.GetComponent<CanvasGroup>();
        buttonUpgradeGroup.interactable = false;
        buttonUpgradeGroup.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
