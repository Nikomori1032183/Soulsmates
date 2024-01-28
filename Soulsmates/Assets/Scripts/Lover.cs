using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Author: Frank Manford
// Description: Class for holding Lover information

public class Lover : MonoBehaviour
{
    [SerializeField] GameLogic gameLogic;

    [SerializeField] public string loverName;
    [SerializeField] Sprite sprite;

    Item likedItem, dislikedItem;
    Location likedLocation;
    People dislikedPerson;

    private void Start()
    {
        
    }

    public void RandomPreferences()
    {
        int rand;

        // Items
        List<Item> itemList = gameLogic.items;
        rand = Random.Range(0, itemList.Count - 1);
        likedItem = itemList[rand];

        itemList.Remove(gameLogic.items[rand]);

        rand = Random.Range(0, itemList.Count - 1);
        dislikedItem = itemList[rand];

        // Location
        rand = Random.Range(0, gameLogic.locations.Count - 1);
        likedLocation = gameLogic.locations[rand];

        // Person
        rand = Random.Range(0, gameLogic.peoples.Count - 1);
        dislikedPerson = gameLogic.peoples[rand];
    }

    public string GetName()
    {
        return loverName;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public Item GetLikedItem()
    {
        return likedItem;
    }

    public Item GetDislikedItem()
    {
        return dislikedItem;
    }

    public Location GetLikedLocation()
    {
        return likedLocation;
    }

    public People GetDislikedPerson()
    {
        return dislikedPerson;
    }
}
