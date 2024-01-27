using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Author: Frank Manford
// Description: Main logic of the game

public class GameLogic : MonoBehaviour
{
    [SerializeField] string itemDirectory, locationDirectory, peopleDirectory;

    public List<Item> items = new List<Item>();
    public List<Location> locations = new List<Location>();
    public List<People> peoples = new List<People>();

    void Start()
    {
        LoadItems();
        LoadLocations();
        LoadPeople();


    }

    void Update()
    {

    }

    public void LoadItems()
    {
        string[] guids;
        guids = AssetDatabase.FindAssets("t:Item", new[] { itemDirectory });
        foreach (string guid in guids)
        {
            Debug.Log("Item: " + AssetDatabase.GUIDToAssetPath(guid));
            Item item = AssetDatabase.LoadAssetAtPath<Item>(AssetDatabase.GUIDToAssetPath(guid));
            items.Add(item);
        }
    }
    public void LoadLocations()
    {
        string[] guids;
        guids = AssetDatabase.FindAssets("t:Location", new[] { locationDirectory });
        foreach (string guid in guids)
        {
            Debug.Log("Location: " + AssetDatabase.GUIDToAssetPath(guid));
            Location location = AssetDatabase.LoadAssetAtPath<Location>(AssetDatabase.GUIDToAssetPath(guid));
            locations.Add(location);
        }
    }

    public void LoadPeople()
    {
        string[] guids;
        guids = AssetDatabase.FindAssets("t:People", new[] { peopleDirectory });
        foreach (string guid in guids)
        {
            Debug.Log("People: " + AssetDatabase.GUIDToAssetPath(guid));
            People people = AssetDatabase.LoadAssetAtPath<People>(AssetDatabase.GUIDToAssetPath(guid));
            peoples.Add(people);
        }
    }
}
