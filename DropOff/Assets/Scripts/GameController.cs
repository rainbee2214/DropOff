using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Direction
{
    Top,
    Right,
    Left,
    Bottom
}
public class GameController : MonoBehaviour
{
    public static GameController controller;

    public static Vector2 mapOffset = new Vector2(0.5f, 4.5f);
    public static HashSet<int> GetRoadSet(int roadType, Direction dir)
    {
        switch (dir)
        {
            default:
            case Direction.Top:
                switch (roadType)
                {
                    default:
                    case 0: return new HashSet<int> { 1, 3, 4, 7, 8, 9 };
                    case 1: return new HashSet<int> { 1, 3, 4, 7, 8, 9 };
                    case 2: return new HashSet<int> { 1, 3, 4, 7, 8, 9 };
                    case 3: return new HashSet<int> { 1, 3, 4, 7, 8, 9 };
                    case 4: return new HashSet<int> { 2, 5, 6 };
                    case 5: return new HashSet<int> { 1, 3, 4, 7, 8, 9 };
                    case 6: return new HashSet<int> { 1, 3, 4, 7, 8, 9 };
                    case 7: return new HashSet<int> { 2, 5, 6 };
                    case 8: return new HashSet<int> { 2, 5, 6 };
                    case 9: return new HashSet<int> { 1, 3, 4, 7, 8, 9 };
                    case 10: return new HashSet<int> { 2, 5, 6 };
                    case 11: return new HashSet<int> { 1, 3, 4, 7, 8, 9 };
                    case 12: return new HashSet<int> { 2, 5, 6 };
                    case 13: return new HashSet<int> { 2, 5, 6 };
                    case 14: return new HashSet<int> { 2, 5, 6 };
                }
            case Direction.Right:
                switch (roadType)
                {
                    default:
                    case 0: return new HashSet<int> { 1, 2, 4, 5, 8, 10 };
                    case 1: return new HashSet<int> { 3, 6, 7, 9 };
                    case 2: return new HashSet<int> { 1, 2, 4, 5, 8, 10 };
                    case 3: return new HashSet<int> { 1, 2, 4, 5, 8, 10 };
                    case 4: return new HashSet<int> { 1, 2, 4, 5, 8, 10 };
                    case 5: return new HashSet<int> { 3, 6, 7, 9 };
                    case 6: return new HashSet<int> { 1, 2, 4, 5, 8, 10 };
                    case 7: return new HashSet<int> { 1, 2, 4, 5, 8, 10 };
                    case 8: return new HashSet<int> { 3, 6, 7, 9 };
                    case 9: return new HashSet<int> { 3, 6, 7, 9 };
                    case 10: return new HashSet<int> { 1, 2, 4, 5, 8, 10 };
                    case 11: return new HashSet<int> { 3, 6, 7, 9 };
                    case 12: return new HashSet<int> { 1, 2, 4, 5, 8, 10 };
                    case 13: return new HashSet<int> { 3, 6, 7, 9 };
                    case 14: return new HashSet<int> { 3, 6, 7, 9 };
                }
            case Direction.Left:
                switch (roadType)
                {
                    default:
                    case 0: return new HashSet<int> { 2, 3, 4, 6, 7, 10 };
                    case 1: return new HashSet<int> { 2, 3, 4, 6, 7, 10 };
                    case 2: return new HashSet<int> { 2, 3, 4, 6, 7, 10 };
                    case 3: return new HashSet<int> { 1, 5, 8, 9 };
                    case 4: return new HashSet<int> { 2, 3, 4, 6, 7, 10 };
                    case 5: return new HashSet<int> { 2, 3, 4, 6, 7, 10 };
                    case 6: return new HashSet<int> { 1, 5, 8, 9 };
                    case 7: return new HashSet<int> { 1, 5, 8, 9 };
                    case 8: return new HashSet<int> { 2, 3, 4, 6, 7, 10 };
                    case 9: return new HashSet<int> { 1, 5, 8, 9 };
                    case 10: return new HashSet<int> { 2, 3, 4, 6, 7, 10 };
                    case 11: return new HashSet<int> { 1, 5, 8, 9 };
                    case 12: return new HashSet<int> { 1, 5, 8, 9 };
                    case 13: return new HashSet<int> { 1, 5, 8, 9 };
                    case 14: return new HashSet<int> { 2, 3, 4, 6, 7, 10 };
                }
            case Direction.Bottom:
                switch (roadType)
                {
                    default:
                    case 0: return new HashSet<int> { 1, 2, 3, 5, 6, 9 };
                    case 1: return new HashSet<int> { 1, 2, 3, 5, 6, 9 };
                    case 2: return new HashSet<int> { 4, 7, 8, 10 };
                    case 3: return new HashSet<int> { 1, 2, 3, 5, 6, 9 };
                    case 4: return new HashSet<int> { 1, 2, 3, 5, 6, 9 };
                    case 5: return new HashSet<int> { 4, 7, 8, 10 };
                    case 6: return new HashSet<int> { 4, 7, 8, 10 };
                    case 7: return new HashSet<int> { 1, 2, 3, 5, 6, 9 };
                    case 8: return new HashSet<int> { 1, 2, 3, 5, 6, 9 };
                    case 9: return new HashSet<int> { 1, 2, 3, 5, 6, 9 };
                    case 10: return new HashSet<int> { 4, 7, 8, 10 };
                    case 11: return new HashSet<int> { 4, 7, 8, 10 };
                    case 12: return new HashSet<int> { 4, 7, 8, 10 };
                    case 13: return new HashSet<int> { 1, 2, 3, 5, 6, 9 };
                    case 14: return new HashSet<int> { 4, 7, 8, 10 };
                }
        }

    }
    public static HashSet<int> GetRoadSet_Classic(int roadType, Direction dir)
    {
        switch (dir)
        {
            default:
            case Direction.Top:
                switch (roadType)
                {
                    default:
                    case 0: return new HashSet<int> { 1, 3, 4, 7, 8, 9, 13 };
                    case 1: return new HashSet<int> { 1, 3, 4, 7, 8, 9, 13 };
                    case 2: return new HashSet<int> { 1, 3, 4, 7, 8, 9, 13 };
                    case 3: return new HashSet<int> { 1, 3, 4, 7, 8, 9, 13 };
                    case 4: return new HashSet<int> { 5, 6, 11, 12, 14 };
                    case 5: return new HashSet<int> { 1, 3, 4, 7, 8, 9, 13 };
                    case 6: return new HashSet<int> { 1, 3, 4, 7, 8, 9, 13 };
                    case 7: return new HashSet<int> { 5, 6, 11, 12, 14 };
                    case 8: return new HashSet<int> { 5, 6, 11, 12, 14 };
                    case 9: return new HashSet<int> { 1, 3, 4, 7, 8, 9, 13 };
                    case 10: return new HashSet<int> { 5, 6, 11, 12, 14 };
                    case 11: return new HashSet<int> { 1, 3, 4, 7, 8, 9, 13 };
                    case 12: return new HashSet<int> { 5, 6, 11, 12, 14 };
                    case 13: return new HashSet<int> { 5, 6, 11, 12, 14 };
                    case 14: return new HashSet<int> { 5, 6, 11, 12, 14 };
                }
            case Direction.Right:
                switch (roadType)
                {
                    default:
                    case 0: return new HashSet<int> { 1, 2, 4, 5, 8, 10, 14 };
                    case 1: return new HashSet<int> { 3, 6, 7, 9, 11, 12, 13 };
                    case 2: return new HashSet<int> { 1, 2, 4, 5, 8, 10, 14 };
                    case 3: return new HashSet<int> { 1, 2, 4, 5, 8, 10, 14 };
                    case 4: return new HashSet<int> { 1, 2, 4, 5, 8, 10, 14 };
                    case 5: return new HashSet<int> { 3, 6, 7, 9, 11, 12, 13 };
                    case 6: return new HashSet<int> { 1, 2, 4, 5, 8, 10, 14 };
                    case 7: return new HashSet<int> { 1, 2, 4, 5, 8, 10, 14 };
                    case 8: return new HashSet<int> { 3, 6, 7, 9, 11, 12, 13 };
                    case 9: return new HashSet<int> { 3, 6, 7, 9, 11, 12, 13 };
                    case 10: return new HashSet<int> { 1, 2, 4, 5, 8, 10, 14 };
                    case 11: return new HashSet<int> { 3, 6, 7, 9, 11, 12, 13 };
                    case 12: return new HashSet<int> { 1, 2, 4, 5, 8, 10, 14 };
                    case 13: return new HashSet<int> { 3, 6, 7, 9, 11, 12, 13 };
                    case 14: return new HashSet<int> { 3, 6, 7, 9, 11, 12, 13 };
                }
            case Direction.Left:
                switch (roadType)
                {
                    default:
                    case 0: return new HashSet<int> { 2, 3, 4, 6, 7, 10, 12 };
                    case 1: return new HashSet<int> { 2, 3, 4, 6, 7, 10, 12 };
                    case 2: return new HashSet<int> { 2, 3, 4, 6, 7, 10, 12 };
                    case 3: return new HashSet<int> { 1, 5, 8, 9, 11, 13, 14 };
                    case 4: return new HashSet<int> { 2, 3, 4, 6, 7, 10, 12 };
                    case 5: return new HashSet<int> { 2, 3, 4, 6, 7, 10, 12 };
                    case 6: return new HashSet<int> { 1, 5, 8, 9, 11, 13, 14 };
                    case 7: return new HashSet<int> { 1, 5, 8, 9, 11, 13, 14 };
                    case 8: return new HashSet<int> { 2, 3, 4, 6, 7, 10, 12 };
                    case 9: return new HashSet<int> { 1, 5, 8, 9, 11, 13, 14 };
                    case 10: return new HashSet<int> { 2, 3, 4, 6, 7, 10, 12 };
                    case 11: return new HashSet<int> { 1, 5, 8, 9, 11, 13, 14 };
                    case 12: return new HashSet<int> { 1, 5, 8, 9, 11, 13, 14 };
                    case 13: return new HashSet<int> { 1, 5, 8, 9, 11, 13, 14 };
                    case 14: return new HashSet<int> { 2, 3, 4, 6, 7, 10, 12 };
                }
            case Direction.Bottom:
                switch (roadType)
                {
                    default:
                    case 0: return new HashSet<int> { 1, 2, 3, 5, 6, 9, 11 };
                    case 1: return new HashSet<int> { 1, 2, 3, 5, 6, 9, 11 };
                    case 2: return new HashSet<int> { 4, 7, 8, 10, 12, 13, 14 };
                    case 3: return new HashSet<int> { 1, 2, 3, 5, 6, 9, 11 };
                    case 4: return new HashSet<int> { 1, 2, 3, 5, 6, 9, 11 };
                    case 5: return new HashSet<int> { 4, 7, 8, 10, 12, 13, 14 };
                    case 6: return new HashSet<int> { 4, 7, 8, 10, 12, 13, 14 };
                    case 7: return new HashSet<int> { 1, 2, 3, 5, 6, 9, 11 };
                    case 8: return new HashSet<int> { 1, 2, 3, 5, 6, 9, 11 };
                    case 9: return new HashSet<int> { 1, 2, 3, 5, 6, 9, 11 };
                    case 10: return new HashSet<int> { 4, 7, 8, 10, 12, 13, 14 };
                    case 11: return new HashSet<int> { 4, 7, 8, 10, 12, 13, 14 };
                    case 12: return new HashSet<int> { 4, 7, 8, 10, 12, 13, 14 };
                    case 13: return new HashSet<int> { 1, 2, 3, 5, 6, 9, 11 };
                    case 14: return new HashSet<int> { 4, 7, 8, 10, 12, 13, 14 };
                }
        }

    }

    GameObject people;
    GameObject[] personPrefabs;
    GameObject crystalPrefab, mushroomPrefab;
    GameObject oilSpillPrefab;

    [HideInInspector]
    public HashSet<Vector2> usedPositions = new HashSet<Vector2>();

    public bool playingGame = true;
    public float spawnPersonDelay = 5f, spawnPowerUpsDelay = 8f, spawnOilSpillDelay = 4f;
    public int peoplePerSpawn = 1;

    public List<Transform> spawnPoints;

    public List<Transform> usedSpawnPoints;

    public List<Car> cars;
    public Dictionary<int, Player> players;

    public Canvas titleCanvas;

    public float width = 9f, height = 9f;

    public UIController uController;

    void Awake()
    {
        uController = GetComponent<UIController>();
        if (controller == null)
        {
            controller = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
        personPrefabs = Resources.LoadAll<GameObject>("Prefabs/People");
        mushroomPrefab = Resources.Load<GameObject>("Prefabs/Mushroom");
        crystalPrefab = Resources.Load<GameObject>("Prefabs/Crystal");
        oilSpillPrefab = Resources.Load<GameObject>("Prefabs/OilSpill");
        people = new GameObject("People");
        CreatePeople(3);
        cars = new List<Car>();
        players = new Dictionary<int, Player>();
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Car"))
        {
            cars.Add(g.GetComponent<Car>());
            players[g.GetComponent<Player>().playerNumber] = g.GetComponent<Player>();
        }
    }

    void Start()
    {
        StartCoroutine(WaitForGameStart());
    }

    IEnumerator WaitForGameStart()
    {
        playingGame = false;
        AudioController.controller.PlayAudio(AudioType.TitleBackground);
        while (!playingGame)
        {
            //display title screen and other options
            yield return null;
        }
        TurnOnCars();
        titleCanvas.gameObject.SetActive(false);
        AudioController.controller.PlayAudio(AudioType.GameBackground);
        //Create new people every 5 seconds
        playingGame = true;
        StartCoroutine(SendPeople());
        StartCoroutine(SendPowerUps());
        StartCoroutine(SendOilSpills());

        while (playingGame)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                uController.UpdatePanel(i);
            }
            yield return null;
        }

        yield return null;
    }

    IEnumerator SendPeople()
    {
        while (playingGame)
        {
            yield return new WaitForSeconds(spawnPersonDelay);
            CreatePeople(peoplePerSpawn);
        }
        yield return null;
    }

    IEnumerator SendPowerUps()
    {
        while (playingGame)
        {
            yield return new WaitForSeconds(spawnPowerUpsDelay);
            if (Random.Range(0, 100) % 3 == 0) CreateCrystals(1);
            if (Random.Range(0, 100) % 3 == 0) CreateMushrooms(1);
        }
        yield return null;
    }

    IEnumerator SendOilSpills()
    {
        while (playingGame)
        {
            CreateOilSpills(1);
            yield return new WaitForSeconds(spawnOilSpillDelay);
        }
        yield return null;
    }

    void TurnOnCars()
    {
        //Put them in different locations on the map
        foreach (Car c in cars)
        {
            TurnOnCar(c);
        }
    }

    public void TurnOnCar(Car c)
    {
        spawnPoints[0].GetComponent<SpawnPoint>().justUsed = true;
        c.transform.position = spawnPoints[0].position;
        usedSpawnPoints.Add(spawnPoints[0]);
        spawnPoints.Remove(spawnPoints[0]);
        c.gameObject.SetActive(true);
    }
    void Update()
    {
        if (Input.GetButtonDown("StartGame"))
        {
            playingGame = true;
        }
    }
    void CreatePeople(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Person g = Instantiate<GameObject>(personPrefabs[Random.Range(0, personPrefabs.Length)]).GetComponent<Person>();

            g.Setup(GetSpawnPosition(), GetSpawnPosition());
            g.tag = "Person";
            g.transform.SetParent(people.transform);
        }
    }

    void CreateCrystals(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Crystal g = Instantiate<GameObject>(crystalPrefab).GetComponent<Crystal>();

            g.Setup(GetSpawnPosition());
        }
    }


    void CreateMushrooms(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Mushroom g = Instantiate<GameObject>(mushroomPrefab).GetComponent<Mushroom>();

            g.Setup(GetSpawnPosition());
        }
    }

    void CreateOilSpills(int n)
    {
        for (int i = 0; i < n; i++)
        {
            OilSpill g = Instantiate<GameObject>(oilSpillPrefab).GetComponent<OilSpill>();

            g.Setup(GetSpawnPosition());
        }
    }
    public Vector2 GetSpawnPosition()
    {
        int t = (int)(width / 2);
        int s = (int)(height / 2);
        Vector2 nextPosition = new Vector2(Random.Range(-t, t), Random.Range(-t, t));
        while (usedPositions.Contains(nextPosition))
        {
            nextPosition = new Vector2(Random.Range(-s, s), Random.Range(-s, s));
        }
        return nextPosition;
    }
}
