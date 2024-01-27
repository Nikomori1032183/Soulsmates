using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Author: Frank Manford
// Description: Class for holding Lover information

public class Lover : MonoBehaviour
{
    string name;
    Sprite sprite;
    Item likedItem, dislikedItem;
    Location likedLocation;
    People dislikedPerson;

    public enum Location
    {
        Stairwell, Gym, Janitors_Closet, Cafeteria, Music_Room, Cooking_Room
    }

    public void RandomizePreferences()
    {
        //Random.Range(1, )
    }

    private void Start()
    {
        
    }

    //public void LoadItems()
    //{
    //    string[] guids;
    //    guids = AssetDatabase.FindAssets("t:Item", new[] { itemDirectory });
    //    foreach (string guid in guids)
    //    {
    //        Debug.Log("Item: " + AssetDatabase.GUIDToAssetPath(guid));
    //        Item item = AssetDatabase.LoadAssetAtPath<Item>(AssetDatabase.GUIDToAssetPath(guid));
    //        items.Add(item);
    //    }
    //}

    //public void LoadItems()
    //{
    //    string[] guids;
    //    guids = AssetDatabase.FindAssets("t:Item", new[] { itemDirectory });
    //    foreach (string guid in guids)
    //    {
    //        Debug.Log("Item: " + AssetDatabase.GUIDToAssetPath(guid));
    //        Item item = AssetDatabase.LoadAssetAtPath<Item>(AssetDatabase.GUIDToAssetPath(guid));
    //        items.Add(item);
    //    }
    //}
}
