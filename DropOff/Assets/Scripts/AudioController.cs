using UnityEngine;
using System.Collections;

public enum AudioType
{
    GameBackground,
    TitleBackground,
    Death,
    DropOff,
    PickUp,
    Collision,
    PowerUp,
    OilSpill
}
public class AudioController : MonoBehaviour
{
   public static AudioController controller;
    AudioSource audioSource;

    public AudioClip gameSong, titleSong, deathSound, dropOffSound, pickUpSound, collisionSound, powerUpSound, oilSpillSound;

    void Awake()
    {
        if (controller == null)
        {
            controller = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioType a)
    {
        switch (a)
        {
            case AudioType.GameBackground:
                audioSource.clip = gameSong;
                audioSource.Play();
                break;
            case AudioType.TitleBackground:
                audioSource.clip = titleSong;
                audioSource.Play();
                break;
            case AudioType.Death:
                audioSource.PlayOneShot(deathSound);
                break;
            case AudioType.DropOff:
                audioSource.PlayOneShot(dropOffSound);
                break;
            case AudioType.PickUp:
                audioSource.PlayOneShot(pickUpSound);
                break;
            case AudioType.Collision:
                audioSource.PlayOneShot(collisionSound);
                break;
            case AudioType.PowerUp:
                audioSource.PlayOneShot(powerUpSound);
                break;
            case AudioType.OilSpill:
                audioSource.PlayOneShot(oilSpillSound);
                break;
        }
    }
}
