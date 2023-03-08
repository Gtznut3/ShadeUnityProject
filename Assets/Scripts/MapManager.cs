using Engine.Utils;
using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : Engine.Utils.Singleton<MapManager>
{
    bool mapIsOpen = false;
    List<Image> iconList = new List<Image>();

    float lastShowMap;

    [SerializeField] private GameObject camBoat;
    [SerializeField] private GameObject camMap;

    // Start is called before the first frame update
    protected override void Start()
    {
        EventManager.Instance.OnMap += showMap;
        lastShowMap = Time.time;

        camBoat.SetActive(true);
        camMap.SetActive(false);
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            EventManager.Instance.LaunchOnMapOpen();
        }
    }

    void showMap()
    {
        mapIsOpen = !mapIsOpen;
        getAllIcons();

        camBoat.SetActive(!mapIsOpen);
        camMap.SetActive(mapIsOpen);

        if (lastShowMap + 0.1f < Time.time)
        {
            foreach (Image icon in iconList)
            {
                if (mapIsOpen)
                {
                    Debug.Log(icon.rectTransform.localScale);
                    icon.rectTransform.localScale *= 10f;
                    Debug.Log(icon.rectTransform.localScale);
                }
                else 
                    icon.rectTransform.localScale *= 0.1f;
            }

            lastShowMap = Time.time;
        }

        SwitchCamera();
    }

    void getAllIcons()
    {
        iconList.Clear();

        foreach (Image icon in FindObjectsOfType<Image>())
        {
            Debug.Log(icon);
            if (icon != null && icon.tag == "Icon")
            {
                iconList.Add(icon);
            }
        }
    }

    void SwitchCamera()
    {

    }
}
