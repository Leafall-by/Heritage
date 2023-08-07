using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        CircleMovement rider = other.gameObject.GetComponent<CircleMovement>(); 
        
        if (rider != null)
        {
            rider.SetInRedZone(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CircleMovement rider = other.gameObject.GetComponent<CircleMovement>(); 
        
        if (rider != null)
        {
            rider.SetInRedZone(false);
        }
    }
}
