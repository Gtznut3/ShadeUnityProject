using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class EndlessWorld : MonoBehaviour
{
    [SerializeField] public const float MaxView = 10;
    [SerializeField] int Size = 240;
    [SerializeField] int SeedValue = 42;
    public Transform PosBoat;
    [SerializeField] Vector3 positionUpgradeIsland;
    public static Vector2 BoatPosition;
    public static Vector2 SpawnBoatPosition;
    int VisibleDst;
    private int NbrIslandRessource = 0;
    private int NbrIslandCivilisation = 0;
    int NbrWithoutIsland = 0;

    Dictionary<Vector2, GenerationWorld> WorldDictionary = new Dictionary<Vector2, GenerationWorld>();
    List<GenerationWorld> WorldListVisibleUpdate = new List<GenerationWorld>();

    void Start()
    {
        SeedValue = Random.Range(0, 100);
        //Mathf.PerlinNoise()
        SpawnBoatPosition = new Vector2(PosBoat.position.x, PosBoat.position.z);
        VisibleDst = Mathf.RoundToInt(Size / MaxView);
        Random.InitState(SeedValue);

        GameObject FirstIslandPrefab = Resources.Load<GameObject>("Island First Level");

        Instantiate(FirstIslandPrefab, positionUpgradeIsland, Quaternion.identity);
    }

    private void Update()
    {
        BoatPosition = new Vector2(PosBoat.position.x, PosBoat.position.z);
        UpdateVisiblePlane();
    }
    void UpdateVisiblePlane()
    {
            for (int i = 0; i < WorldListVisibleUpdate.Count; i++)
            {
                WorldListVisibleUpdate[i].SetVisible(false);
            }
            WorldListVisibleUpdate.Clear();
            int CurrentPLaneX = Mathf.RoundToInt(BoatPosition.x / Size);
            int CurrentPLaneY = Mathf.RoundToInt(BoatPosition.y / Size);

            for (int Yoffset = -VisibleDst; Yoffset <= VisibleDst; Yoffset++)
            {
                for (int Xoffset = -VisibleDst; Xoffset <= VisibleDst; Xoffset++)
                {
                    Vector2 PlanePos = new Vector2(CurrentPLaneX + Xoffset, CurrentPLaneY + Yoffset);

                if (WorldDictionary.ContainsKey(PlanePos))
                {
                    WorldDictionary[PlanePos].UpdateWorld();
                    if (WorldDictionary[PlanePos].IsVisible())
                    {
                        WorldListVisibleUpdate.Add(WorldDictionary[PlanePos]);
                    }
                }
                else
                {
                    try
                    {
                        if (NbrWithoutIsland == 0)
                        {
                            if ((Mathf.Sqrt(Mathf.Pow((PlanePos.x - SpawnBoatPosition.x), 2) + Mathf.Pow((PlanePos.y - SpawnBoatPosition.y), 2))) <= (Size * 1))
                            {
                                WorldDictionary.Add(PlanePos, new GenerationWorld(PlanePos, Size, NbrIslandRessource, NbrIslandCivilisation));
                                NbrIslandRessource++;
                                NbrIslandCivilisation++;
                                NbrWithoutIsland = 6;
                            }
                        } else
                            NbrWithoutIsland--;
                    }
                    catch
                    {
                    }
                    }
                }
            }
    }
    public class GenerationWorld
    {
        GameObject PlaneObject;
        GameObject IsleCivilisationObject;
        GameObject IsleRessourceObject;
        GameObject RockObject;
        GameObject PlanePrefab = Resources.Load<GameObject>("Plane");
        GameObject IslandCivilisationPrefab = Resources.Load<GameObject>("Civilisation Island");
        GameObject IslandRessourcePrefab = Resources.Load<GameObject>("Ressources Island");
        GameObject RockPrefab;
        Vector2 PositionPlane;
        Bounds boundsPlane;

        public GenerationWorld(Vector2 coord, int size, int NbrIslandRessource, int NbrIslandCivilisation)
        {
            PositionPlane = coord * size;
            boundsPlane = new Bounds(PositionPlane, Vector2.one * size);
            Vector3 PositionV3Plane = new Vector3(PositionPlane.x, 0, PositionPlane.y);

            PlaneObject = Instantiate(PlanePrefab);
            PlaneObject.transform.position = PositionV3Plane;
            SetVisible(false);

            switch(Random.Range(0, 500))
            {
                case >495:
                    CreatIslandHuman(NbrIslandCivilisation);
                    break;
                case <1:
                    CreatIslandRessource(NbrIslandRessource);
                    break;
                case <20:
                    CreatRock();
                    break;
                default:
                    break;
            }
        }
        public void CreatIslandHuman(int NbrIslandCivilisation)
        {
            Vector3 PositionV3Island = new Vector3(PositionPlane.x, 0f, PositionPlane.y);
            IsleCivilisationObject = Instantiate(IslandCivilisationPrefab);
            IsleCivilisationObject.name = "Civilisation Island " + NbrIslandCivilisation;
            IsleCivilisationObject.transform.position = PositionV3Island;
        }
        public void CreatIslandRessource(int NbrIslandRessource)
        {
            //GameObject IsleObject;
            Vector3 PositionV3Island = new Vector3(PositionPlane.x, 0f, PositionPlane.y);
            IsleRessourceObject = Instantiate(IslandRessourcePrefab);
            IsleRessourceObject.name = "Island Ressource " + NbrIslandRessource;
            IsleRessourceObject.transform.position = PositionV3Island;

        }
        public void CreatRock()
        {
            switch (Random.Range(0, 100))
            {
                case > 50:
                    RockPrefab = Resources.Load<GameObject>("Rock");
                    break;
                default:
                    RockPrefab = Resources.Load<GameObject>("Rock1");
                    break;
            }
            Vector3 PositionV3Island = new Vector3(PositionPlane.x, 0f, PositionPlane.y);
            RockObject = Instantiate(RockPrefab);
            RockObject.transform.position = PositionV3Island;
        }
        public void UpdateWorld()
        {
            float BoatDistForObbj = Mathf.Sqrt(boundsPlane.SqrDistance(PositionPlane));
            bool visiblePlane = BoatDistForObbj <= MaxView;
            SetVisible(visiblePlane);
        }

        public void SetVisible(bool visible)
        {
            PlaneObject.SetActive(visible);
            //RockObject.SetActive(visible);
/*            IsleCivilisationObject.SetActive(visible);
            IsleRessourceObject.SetActive(visible);*/
        }

        public bool IsVisible()
        {
            return PlaneObject.activeSelf;
        }
    }
}

