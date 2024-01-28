using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Frank Manford
// Description: Class for holding player data

public class PlayerData : MonoBehaviour
{
    string playerName;
    [SerializeField] Location currentLocation;
    List<Task> playerTasks = new List<Task>();
    int affection;
    Lover lover;
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SetName(string name)
    {
        this.playerName = name;
    }

    public string GetName()
    {
        return playerName;
    }

    public void AddTask(Task task)
    {
        playerTasks.Add(task);
    }

    public void RemoveTask(Task task)
    {
        playerTasks.Remove(task);
    }
    public Lover GetLover()
    {
        return lover;
    }

    public void SetCurrentLocation(Location here)
    {
        this.currentLocation = here;
    }

    public Location GetCurrentLocation()
    {
        return currentLocation;
    }

    public void SetAffection(int love)
    {
        this.affection += love;
    }

    public int GetAffection()
    {
        return affection;
    }
}
