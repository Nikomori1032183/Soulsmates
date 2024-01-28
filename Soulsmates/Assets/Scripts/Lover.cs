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

    //enum Lover
    //{
    //    Goose, Greg, Nyal, Onna
    //}

    //Lover loverInfo;

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

    //public string loverDialogue(InteractLover usedLover)
    //{

    //    usedLover.lover.loverName = loverName; //save me

    //    switch (loverInfo)
    //    {
    //        case Lover.Goose:
    //            string find = "Assets/Imports/Dialogue/Dialogue - Goose/HJONK";
    //            Debug.Log("Goose Dialogue Library");
    //            return find;

    //        case Lover.Greg:
    //            string find1 = "Assets/Imports/Dialogue/Dialogue - Greg Stuttershock/GREG";
    //            Debug.Log("Greg Dialogue Library");
    //            return find1;

    //        case Lover.Nyal:
    //            string find2 = "Assets/Imports/Dialogue/Dialogue - Nyal_hothep/CTHULHU";
    //            Debug.Log("Nyal Dialogue Library");
    //            return find2;

    //        case Lover.Onna:
    //            string find3 = "Assets/Imports/Dialogue/Dialogue - Onna-chan/ANIME";
    //            Debug.Log("Onna Dialogue Library");
    //            return find3;

    //        default:
    //            break;
    //    }
    //}
}
