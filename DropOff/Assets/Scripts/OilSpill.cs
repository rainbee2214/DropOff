﻿using UnityEngine;
using System.Collections;

public class OilSpill : MonoBehaviour
{

    //Fade out after a time
    //Make collectables into object pools

    float aliveTime = 5f;
    public float timeStarted;

    public void OnEnable()
    {
        timeStarted = Time.time;
    }

    void Update()
    {
        if (Time.time > timeStarted + aliveTime)
        {
            TurnOff();
        }
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }
    public void Setup(Vector2 position)
    {
        transform.position = position + GameController.mapOffset + new Vector2(0.5f, 0.5f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Car")
        {
            Car p = other.GetComponent<Car>();
            //p.ChangeDirection();
            float delay = 2f;
            p.ChangeSpeed(delay, 0.25f);
            StartCoroutine(TurnOff(delay));
            AudioController.controller.PlayAudio(AudioType.OilSpill);
        }
    }

    IEnumerator TurnOff(float delay)
    {
        yield return new WaitForSeconds(delay);
            gameObject.SetActive(false);
    }
}
