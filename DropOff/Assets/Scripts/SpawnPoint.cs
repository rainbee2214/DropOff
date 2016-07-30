using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour
{

    public bool justUsed = false;

    void OnTriggerExit2D(Collider2D other)
    {
        if (justUsed)
        {
            GameController.controller.usedSpawnPoints.Remove(transform);
            GameController.controller.spawnPoints.Add(transform);
            justUsed = false;
        }
    }
}
