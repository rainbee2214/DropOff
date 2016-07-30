using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MapColor
{
    White,
    Green,
    Grey
}

public enum Direction
{
    Top,
    Right,
    Left,
    Bottom
}
public class EditorMapBuilder : MonoBehaviour
{

    public static Sprite[] topRow, middleRow, bottomRow;

    [MenuItem("MapGeneration/Create Default Map")]
    private static void CreateDefaultMap()
    {
        Debug.Log("Building default map");
        CreateWhiteMap_9x9();
    }

    [MenuItem("MapGeneration/Create 9x9 Map/White")]
    private static void CreateWhiteMap_9x9()
    {
        Debug.Log("Building a 9x9 white map");
        CreateMap(9, 9, MapColor.White);
    }
    [MenuItem("MapGeneration/Create 9x9 Map/Green")]
    private static void CreateGreenMap_9x9()
    {
        Debug.Log("Building a 9x9 green map");
        CreateMap(9, 9, MapColor.Green);
    }
    [MenuItem("MapGeneration/Create 9x9 Map/Grey")]
    private static void CreateGreyMap_9x9()
    {
        Debug.Log("Building a 9x9 grey map");
        CreateMap(9, 9, MapColor.Grey);
    }
    [MenuItem("MapGeneration/Create Roads/9x9")]
    private static void CreateRoads_9x9()
    {
        CreateRoads(9, 9);
    }

    [MenuItem("MapGeneration/DeleteMap/Delete All Active Base Tiles")]
    private static void DeleteActiveBaseTiles()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("MapTileBase"))
        {
            if (g.activeInHierarchy) DestroyImmediate(g);
        }
    }
    [MenuItem("MapGeneration/DeleteMap/Delete All Base Tiles")]
    private static void DeleteBaseTiles()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("MapTileBase"))
        {
            DestroyImmediate(g);
        }
    }
    [MenuItem("MapGeneration/DeleteMap/Delete All Road Tiles")]
    private static void DeleteRoadTiles()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("MapTileRoad"))
        {
            DestroyImmediate(g);
        }
    }
    [MenuItem("MapGeneration/DeleteMap/Delete All People")]
    private static void DeletePeople()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Person"))
        {
            DestroyImmediate(g);
        }
    }

    [MenuItem("MapGeneration/CreatePeople")]
    private static void CreatePeopleMenu()
    {
        CreatePeople(9);
    }

    static void CreateMap(int w = 9, int h = 9, MapColor c = MapColor.White)
    {

        topRow = Resources.LoadAll<Sprite>("MapTiles/TopRows");
        middleRow = Resources.LoadAll<Sprite>("MapTiles/MiddleRows");
        bottomRow = Resources.LoadAll<Sprite>("MapTiles/BottomRows");

        Sprite[] currentRow = middleRow;

        Vector2 offset = new Vector2(-w / 2f, -h / 2f);
        int index = 1;

        GameObject p = new GameObject("Map");
        for (int k = 0; k < h; k++)
        {
            for (int i = 0; i < w; i++)
            {
                //If top row, use top, if, bottom row use bottom, if left edge use edge, if right edge use edge
                if (k == 0) { currentRow = bottomRow; } else if (k == h - 1) { currentRow = topRow; } else { currentRow = middleRow; }
                if (i == 0) { index = 0; } else if (i == w - 1) { index = 2; } else { index = 1; }


                GameObject g = new GameObject("MapTile");
                g.AddComponent<SpriteRenderer>().sprite = currentRow[index + (int)c * 3];
                g.transform.position = new Vector2(i, k) + offset;
                g.tag = "MapTileBase";
                g.transform.SetParent(p.transform);

            }
        }

        CreateRoads(w, h);
    }

    static void CreateRoads(int w = 9, int h = 9)//, RoadColor c = RoadColor.White)
    {


        Sprite[] roads = Resources.LoadAll<Sprite>("MapRoads");
        HashSet<int> possibleRoads = new HashSet<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

        HashSet<int> topEdge = new HashSet<int> { 4, 7, 8, 12, 13, 14 };
        HashSet<int> rightEdge = new HashSet<int> { 1, 5, 8, 9, 11, 13, 14 };
        HashSet<int> LeftEdge = new HashSet<int> { 3, 6, 7, 9, 11, 12, 13 };
        HashSet<int> bottomEdge = new HashSet<int> { 2, 5, 6, 10, 11, 12, 14 };

        Vector2 offset = new Vector2(-w / 2f, -h / 2f);
        int index = 0;

        GameObject roadPrefab = Resources.Load<GameObject>("Prefabs/RoadTile");
        GameObject[,] roadTiles = new GameObject[w, h];

        GameObject roadP = new GameObject("Roads");
        for (int k = 0; k < h; k++)
        {
            for (int i = 0; i < w; i++)
            {
                possibleRoads = new HashSet<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
                if (k == 0)
                {
                    possibleRoads.IntersectWith(bottomEdge);
                }
                else if (k == h - 1)
                {
                    possibleRoads.IntersectWith(topEdge);
                }

                if (k > 0)
                {
                    //union with the road below's possibleTop
                    possibleRoads.IntersectWith(roadTiles[i, k - 1].GetComponent<RoadTile>().possibleTop);
                }

                if (i == 0)
                {
                    possibleRoads.IntersectWith(LeftEdge);
                }
                else if (i == w - 1)
                {
                    possibleRoads.IntersectWith(rightEdge);
                }

                if (i > 0)
                {
                    possibleRoads.IntersectWith(roadTiles[i - 1, k].GetComponent<RoadTile>().possibleRight);
                }

                if (possibleRoads.Count > 0)
                {
                    index = new List<int>(possibleRoads)[Random.Range(0, possibleRoads.Count)];
                }
                else
                {
                    //try classic
                    possibleRoads = new HashSet<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
                    if (k == 0)
                    {
                        possibleRoads.IntersectWith(bottomEdge);
                    }
                    else if (k == h - 1)
                    {
                        possibleRoads.IntersectWith(topEdge);
                    }

                    if (k > 0)
                    {
                        possibleRoads.IntersectWith(roadTiles[i, k - 1].GetComponent<RoadTile>().possibleTop_Classic);
                    }

                    if (i == 0)
                    {
                        possibleRoads.IntersectWith(LeftEdge);
                    }
                    else if (i == w - 1)
                    {
                        possibleRoads.IntersectWith(rightEdge);
                    }

                    if (i > 0)
                    {
                        possibleRoads.IntersectWith(roadTiles[i - 1, k].GetComponent<RoadTile>().possibleRight_Classic);
                    }
                    index = new List<int>(possibleRoads)[Random.Range(0, possibleRoads.Count)];
                    if (possibleRoads.Count == 0)
                    {
                        index = -1;
                    }
                }

                GameObject g = Instantiate<GameObject>(roadPrefab);
                SpriteRenderer sr = g.GetComponent<SpriteRenderer>();
                sr.sprite = (index == -1 ? null : roads[index]);
                sr.sortingOrder += 10;
                g.transform.position = new Vector2(i, k) + offset;
                g.tag = "MapTileRoad";
                g.GetComponent<RoadTile>().Setup(index);

                g.transform.SetParent(roadP.transform);
                roadTiles[i, k] = g;

            }
        }
    }

    static void CreatePeople(int n)
    {
        GameObject people = new GameObject("People");
        GameObject[] personPrefabs = Resources.LoadAll<GameObject>("Prefabs/People");
        HashSet<Vector2> usedPositions = new HashSet<Vector2>();
        for (int i = 0; i < n; i++)
        {
            Person g = Instantiate<GameObject>(personPrefabs[Random.Range(0, personPrefabs.Length)]).GetComponent<Person>();
            Vector2 nextPosition = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
            while (usedPositions.Contains(nextPosition))
            {
                nextPosition = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
            }
            Vector2 nextPosition2 = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
            while (usedPositions.Contains(nextPosition2))
            {
                nextPosition2 = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
            }

            g.Setup(nextPosition, nextPosition2);
            g.tag = "Person";
            g.transform.SetParent(people.transform);
        }
    }
}
