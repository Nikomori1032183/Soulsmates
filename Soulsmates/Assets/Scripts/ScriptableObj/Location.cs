using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class Location : ScriptableObject
{
    public string locationName;
    public GameObject locationZone;
    PlayerData playerdata;

    //OnTriggerEnter(Collider other)
    //{
    //    playerdata.SetCurrentLocation();
    //}
}
