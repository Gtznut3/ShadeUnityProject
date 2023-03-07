using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EndlessWorld : MonoBehaviour
{
    [SerializeField] public const float MaxView = 10;
    [SerializeField] int Size = 240;
    [SerializeField] int SeedValue = 42;
    public Transform PosBoat;
    public static Vector2 BoatPosition;
    public static Vector2 SpawnBoatPosition;
    int VisibleDst;
    private int NbrIslandRessource = 0;
    private int NbrIslandCivilisation = 0;

    Dictionary<Vector2, GenerationWorld> WorldDictionary = new Dictionary<Vector2, GenerationWorld>();
    List<GenerationWorld> WorldListVisibleUpdate = new List<GenerationWorld>();

    void Start()
    {
        SpawnBoatPosition = new Vector2(PosBoat.position.x, PosBoat.position.z);
        VisibleDst = Mathf.RoundToInt(Size / MaxView);
        Random.InitState(SeedValue);
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
                        Debug.Log("Je suis dans le dico");
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
                        if ((Mathf.Sqrt(Mathf.Pow((PlanePos.x - SpawnBoatPosition.x), 2) + Mathf.Pow((PlanePos.y - SpawnBoatPosition.y), 2))) <= (Size * 1))
                            {
                                /*Debug.Log(PlanePos);
                                Debug.Log(Size);
                                Debug.Log(NbrIslandRessource);
                                Debug.Log(NbrIslandCivilisation);*/
                                WorldDictionary.Add(PlanePos, new GenerationWorld(PlanePos, Size, NbrIslandRessource, NbrIslandCivilisation));
                                NbrIslandRessource++;
                                NbrIslandCivilisation++;
                            }
                            

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
        GameObject PlanePrefab = Resources.Load<GameObject>("Plane");
        Vector2 PositionPlane;
        Bounds boundsPlane;
        public GenerationWorld(Vector2 coord, int size, int NbrIslandRessource, int NbrIslandCivilisation)
        {
            Debug.Log("genere map");
            PositionPlane = coord * size;
            boundsPlane = new Bounds(PositionPlane, Vector2.one * size);
            Vector3 PositionV3Plane = new Vector3(PositionPlane.x, 0, PositionPlane.y);

            PlaneObject = Instantiate(PlanePrefab);
            PlaneObject.transform.position = PositionV3Plane;
            SetVisible(false);
            switch(Random.Range(0, 500))
            {
                case >498:
                    CreatIslandHuman(NbrIslandCivilisation);
                    break;
                case <1:
                    CreatIslandRessource(NbrIslandRessource);
                    break;
                default:
                    break;
            }
        }
        private void CreatIslandHuman(int NbrIslandCivilisation)
        {
            Debug.Log("Civilisation Island");
            GameObject IslandPrefab = Resources.Load<GameObject>("Civilisation Island");
            Vector3 PositionV3Island = new Vector3(PositionPlane.x, 0f, PositionPlane.y);
            GameObject IsleObject = Instantiate(IslandPrefab);
            IsleObject.name = "Civilisation Island " + NbrIslandCivilisation;
            IsleObject.transform.position = PositionV3Island;
        }
        private void CreatIslandRessource(int NbrIslandRessource)
        {
            //GameObject IsleObject;
            GameObject IslandPrefab = Resources.Load<GameObject>("Ressources Island");
            Vector3 PositionV3Island = new Vector3(PositionPlane.x, 0f, PositionPlane.y);
            GameObject IsleObject = Instantiate(IslandPrefab);
            IsleObject.name = "Island Ressource " + NbrIslandRessource;
            IsleObject.transform.position = PositionV3Island;

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
            //IsleObject.SetActive(visible);
        }

        public bool IsVisible()
        {
            return PlaneObject.activeSelf;
        }
    }
}

