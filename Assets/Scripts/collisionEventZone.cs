using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class collisionEventZone : MonoBehaviour, AbleToPause
{
    bool isPause = false;

    public void Continue()
    {
        isPause = false;
    }

    public void Pause()
    {
        isPause = true;
    }

    NavMeshAgent _playerNav;

    GameObject _islandPanel;

    updateTextScript _textScript;
    updateTextScript _islandNameScript;

    islandCoinsScript _coinsIslandScript;
    islandRockScript _rockIslandScript;
    islandWoodScript _woodIslandScript;
    islandHumanScript _humanIslandScript;
    collectRessourcesIslandScript _collectRessourcesIslandScript;

    GameObject[] listTextRessources;

    Collider colliderTriggered;

    private void OnTriggerEnter(Collider other)
    {
    }
    private void OnTriggerExit(Collider other)
    {
        colliderTriggered = null;
    }

    private void OnTriggerStay(Collider other)
    {
        colliderTriggered = other;
    }

    // Start is called before the first frame update
    void Awake()
    {
        _playerNav = GetComponent<NavMeshAgent>();

        _islandPanel = GameObject.Find("Island Panel Test");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPause)
        {
            listTextRessources = GameObject.FindGameObjectsWithTag("TextRessources");

            UpdateUI();
        }
    }

    void UpdateUI()
    {
        if (colliderTriggered != null)
        {
            _coinsIslandScript = colliderTriggered.gameObject.GetComponentInParent<islandCoinsScript>();
            _rockIslandScript = colliderTriggered.gameObject.GetComponentInParent<islandRockScript>();
            _woodIslandScript = colliderTriggered.gameObject.GetComponentInParent<islandWoodScript>();
            _humanIslandScript = colliderTriggered.gameObject.GetComponentInParent<islandHumanScript>();

            bool coins = true;
            bool rocks = true;
            bool woods = true;
            bool humans = true;

            for (int i = 0; i < listTextRessources.Length; i++)
            {
                _textScript = listTextRessources[i].GetComponentInChildren<updateTextScript>();

                if (coins && _textScript != null && _coinsIslandScript != null)
                {
                    _textScript.setTextValue("Coins : " + _coinsIslandScript.GetNumber().ToString());
                    coins = false;
                }
                else if (rocks && _textScript != null && _rockIslandScript != null)
                {
                    _textScript.setTextValue("Rock : " + _rockIslandScript.GetNumber().ToString());
                    rocks = false;
                }
                else if (woods && _textScript != null && _woodIslandScript != null)
                {
                    _textScript.setTextValue("Wood : " + _woodIslandScript.GetNumber().ToString());
                    woods = false;
                }
                else if (humans && _textScript != null && _humanIslandScript != null)
                {
                    _textScript.setTextValue("Human : " + _humanIslandScript.GetNumber().ToString());
                    humans = false;
                }
                else
                {
                    _textScript.setTextValue("");
                }
            }

            // Edit Button Link To Island
            _collectRessourcesIslandScript = _islandPanel.GetComponentInChildren<collectRessourcesIslandScript>();
            if (_collectRessourcesIslandScript != null) _collectRessourcesIslandScript.SetIslandObject(colliderTriggered.transform.parent.name);

            // Edit island name Text
            _islandNameScript = GameObject.FindGameObjectWithTag("TextIslandName").GetComponent<updateTextScript>();
            if (_islandNameScript != null && colliderTriggered != null) _islandNameScript.setTextValue(colliderTriggered.transform.parent.name);
        }
    }
}