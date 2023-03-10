using Engine.Utils;
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

    [SerializeField] private GameObject miniMap;

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

        SwitchCamera();

        showMiniMap();

        if (lastShowMap + 0.1f < Time.time)
        {
            foreach (Image icon in iconList)
            {
                if (mapIsOpen)
                {
                    if (icon.name == "Boat_Icon")
                        icon.rectTransform.localScale *= 6f;
                    else
                        icon.rectTransform.localScale *= 3f;
                }
                else
                {
                    if (icon.name == "Boat_Icon")
                        icon.rectTransform.localScale /= 6f;
                    else
                        icon.rectTransform.localScale /= 3f;
                }
            }

            lastShowMap = Time.time;
        }

    }

    void getAllIcons()
    {
        iconList.Clear();

        foreach (Image icon in FindObjectsOfType<Image>())
        {
            if (icon != null && icon.tag == "Icon")
            {
                iconList.Add(icon);
            }
        }
    }

    void SwitchCamera()
    {
        camBoat.SetActive(!mapIsOpen);
        camMap.SetActive(mapIsOpen);
    }

    void showMiniMap()
    {
        miniMap.SetActive(!mapIsOpen);
    }
}
