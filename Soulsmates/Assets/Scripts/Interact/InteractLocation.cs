using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLocation : MonoBehaviour
{
    public Location location;
    [SerializeField] TurnHandler onTurnHandler;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onTurnHandler.GetPlayer().SetCurrentLocation(location);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onTurnHandler.GetPlayer().SetCurrentLocation(null);
        }
    }
}
