using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player has entered trigger zone."); 
            gameObject.BroadcastMessage("OpenGate");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player has left trigger zone.");
            gameObject.BroadcastMessage("CloseGate");
        }
        
    }
}
