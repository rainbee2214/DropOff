using UnityEngine;
using System.Collections;

public class Mushroom : MonoBehaviour
{
    float aliveTime = 25f;
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
            Player p = other.GetComponent<Player>();
            p.numberOfMushrooms++;
            GameController.controller.uController.UpdatePanel(p.playerNumber);
            gameObject.SetActive(false);
            AudioController.controller.PlayAudio(AudioType.PowerUp);
        }
    }
}
