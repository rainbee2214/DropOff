using UnityEngine;
using System.Collections;

public class DropOffLocation : MonoBehaviour
{
    public  Person myPerson;


    public void OnTriggerEnter2D(Collider2D other)
    {
        myPerson.DropOff();
        other.GetComponent<Car>().DropOff(myPerson);
        other.GetComponent<Player>().DropOff();
    }
}
