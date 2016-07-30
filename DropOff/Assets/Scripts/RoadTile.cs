using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoadTile : MonoBehaviour
{

    public int roadType = 0;
    public HashSet<int> possibleTop, possibleRight, possibleLeft, possibleBottom;
    public HashSet<int> possibleTop_Classic, possibleRight_Classic, possibleLeft_Classic, possibleBottom_Classic;

    public bool hasTop, hasRight, hasLeft, hasBottom;

    public void Setup(int rt)
    {
        roadType = rt;
        SetSides();
        possibleTop = GameController.GetRoadSet(roadType, Direction.Top);
        possibleRight = GameController.GetRoadSet(roadType, Direction.Right);
        possibleLeft = GameController.GetRoadSet(roadType, Direction.Left);
        possibleBottom = GameController.GetRoadSet(roadType, Direction.Bottom);

        possibleTop_Classic = GameController.GetRoadSet_Classic(roadType, Direction.Top);
        possibleRight_Classic = GameController.GetRoadSet_Classic(roadType, Direction.Right);
        possibleLeft_Classic = GameController.GetRoadSet_Classic(roadType, Direction.Left);
        possibleBottom_Classic = GameController.GetRoadSet_Classic(roadType, Direction.Bottom);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Car")
        {
            other.GetComponent<Car>().HitRoadTile(hasTop, hasRight, hasLeft, hasBottom);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Car")
        {
            other.GetComponent<Car>().LeftRoadTile(hasTop, hasRight, hasLeft, hasBottom);
        }
    }

    public void SetSides()
    {
        switch (roadType)
        {
            case 0: hasTop = true; hasRight = true; hasLeft = true; hasBottom = true; break;
            case 1: hasTop = true; hasRight = false; hasLeft = true; hasBottom = true; break;
            case 2: hasTop = true; hasRight = true; hasLeft = true; hasBottom = false; break;
            case 3: hasTop = true; hasRight = true; hasLeft = false; hasBottom = true; break;
            case 4: hasTop = false; hasRight = true; hasLeft = true; hasBottom = true; break;
            case 5: hasTop = true; hasRight = false; hasLeft = true; hasBottom = false; break;
            case 6: hasTop = true; hasRight = true; hasLeft = false; hasBottom = false; break;
            case 7: hasTop = false; hasRight = true; hasLeft = false; hasBottom = true; break;
            case 8: hasTop = false; hasRight = false; hasLeft = true; hasBottom = true; break;
            case 9: hasTop = true; hasRight = false; hasLeft = false; hasBottom = true; break;
            case 10: hasTop = false; hasRight = true; hasLeft = true; hasBottom = false; break;
            case 11: hasTop = true; hasRight = false; hasLeft = false; hasBottom = false; break;
            case 12: hasTop = false; hasRight = true; hasLeft = false; hasBottom = false; break;
            case 13: hasTop = false; hasRight = false; hasLeft = false; hasBottom = true; break;
            case 14: hasTop = false; hasRight = false; hasLeft = true; hasBottom = false; break;
        }
    }
}
