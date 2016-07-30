using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public string playerName;
    public int score;
    public int numberOfCrystals, numberOfMushrooms;
    Car c;
    public float currentSpeedUpTime = 2f;
    public int multiplier = 2;
    public int playerNumber;

    void Awake()
    {
        c = GetComponent<Car>();
        c.playerNumber = playerNumber;
    }
    public void UseCrystal()
    {
        if (numberOfCrystals > 0)
        {
            numberOfCrystals--;
        }
    }

    public void UseMushroom()
    {
        if (numberOfMushrooms > 0)
        {
            numberOfMushrooms--;
            StartCoroutine(c.SpeedUp(currentSpeedUpTime, multiplier));
        }
    }

    public void DropOff()
    {
        //Add multiplier
        score += 10;
    }
}
