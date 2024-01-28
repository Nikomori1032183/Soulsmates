using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Author: Frank Manford
// Description: Main logic of the game

public class GameLogic : MonoBehaviour
{
    [SerializeField] string itemDirectory, locationDirectory, peopleDirectory;

    public List<Item> items = new List<Item>();
    public List<Location> locations = new List<Location>();
    public List<People> peoples = new List<People>();

    [SerializeField] PlayerData player1, player2, player3, player4;

    [SerializeField] Lover goose, guy, horror, anime;
    public List<Lover> lovers = new List<Lover>();

    [SerializeField] FetchTask fetchTask;
    [SerializeField] EscortTask escortTask;
    [SerializeField] ConfrontTask confrontTask;

    void Start()
    {
        //events
        TurnHandler.OnTurnChangePlayerData += SetPlayerTasks;

        //TurnHandler

        //logic
        LoadItems();
        LoadLocations();
        LoadPeople();

        lovers.Add(goose);
        lovers.Add(guy);
        lovers.Add(horror);
        lovers.Add(anime);

        

        // load main menu scene
        SceneManager.LoadScene("MainMenu");

        // if exit is clicked 
        // stop

        // if start is clicked
        // start

        //Randomize players love interest
        //set each players love interest
        int rand = Random.Range(0, lovers.Count - 1);
        player1.SetLover(lovers[rand]);
        lovers.Remove(lovers[rand]);

        rand = Random.Range(0, lovers.Count - 1);
        player2.SetLover(lovers[rand]);
        lovers.Remove(lovers[rand]);

        rand = Random.Range(0, lovers.Count - 1);
        player3.SetLover(lovers[rand]);
        lovers.Remove(lovers[rand]);

        player4.SetLover(lovers[0]);

        //randomize love interests
        goose.RandomPreferences();
        guy.RandomPreferences();
        horror.RandomPreferences();
        anime.RandomPreferences();

        //set current player
        //change ui color
        //start timer

        //if the dialogue is showing stop timer

        //if players has 100 affectioon
        //start final date
        // then load play win scene

        // When time runs out 
        // if all players have had a turn
        // check if it is day 5
        // if its not increment day and oop back to set current player/ change player
        // if it is load the game over scene
    }

    void Update()
    {

    }

    public void SetPlayerTasks(PlayerData playerData)
    {
        playerData.ResetTasks();
        
        fetchTask.SetItem(playerData.GetLover().GetLikedItem());
        escortTask.SetLocation(playerData.GetLover().GetLikedLocation());
        confrontTask.SetPerson(playerData.GetLover().GetDislikedPerson());

        playerData.AddTask(fetchTask);
        playerData.AddTask(escortTask);
        playerData.AddTask(confrontTask);
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

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
