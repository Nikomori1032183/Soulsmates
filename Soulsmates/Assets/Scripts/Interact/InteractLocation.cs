using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLocation : MonoBehaviour
{
    public Location location;
    [SerializeField] CharacterData characterData;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            characterData.SetCurrentLocation(location);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            characterData.SetCurrentLocation(null);
        }
    }
}
