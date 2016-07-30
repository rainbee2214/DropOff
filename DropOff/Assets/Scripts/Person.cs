using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour
{
    DropOffLocation dropOffLocation;

    SpriteRenderer[] srs;
    void Awake()
    {
        srs = GetComponentsInChildren<SpriteRenderer>();
        dropOffLocation = GetComponentInChildren<DropOffLocation>();
    }
    float aliveTime = 30f;
    public float timeStarted;

    public void OnEnable()
    {
        timeStarted = Time.time;
    }

    public void Pickup()
    {
        Debug.Log("It took you " + Mathf.RoundToInt(Time.time - timeStarted) +  " too many seconds to get here!");
        AudioController.controller.PlayAudio(AudioType.PickUp);
        //Create a drop off location
        srs[0].enabled = false;
        srs[1].enabled = true;
        GameController.controller.usedPositions.Remove(transform.position);
    }

    public void DropOff()
    {
        AudioController.controller.PlayAudio(AudioType.DropOff);
        //Reset and go back into person pool
        srs[0].enabled = false;
        srs[1].enabled = false;
        GameController.controller.usedPositions.Remove(dropOffLocation.transform.position);

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger enter person");
        Pickup();
        other.GetComponent<Car>().Pickup(this);
    }

    public void Setup(Vector2 personPosition, Vector2 dropOffPosition)
    {
        transform.position = personPosition + GameController.mapOffset + new Vector2(0.5f, 0.5f);
        dropOffLocation = GetComponentInChildren<DropOffLocation>();
        dropOffLocation.transform.position = dropOffPosition + GameController.mapOffset + new Vector2(0.5f, 0.5f);
    }
}
