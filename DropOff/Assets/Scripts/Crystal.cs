using UnityEngine;
using System.Collections;

public class Crystal : MonoBehaviour
{

    public void Setup(Vector2 position)
    {
        transform.position = position + GameController.mapOffset + new Vector2(0.5f, 0.5f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Car")
        {
            Player p = other.GetComponent<Player>();
            p.numberOfCrystals++;
            GameController.controller.uController.UpdatePanel(p.playerNumber);
            gameObject.SetActive(false);
            AudioController.controller.PlayAudio(AudioType.PowerUp);
        }
    }
}
