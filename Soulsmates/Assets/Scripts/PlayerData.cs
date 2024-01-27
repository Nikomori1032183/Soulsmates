using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Frank Manford
// Description: Class for holding player data

public class PlayerData : MonoBehaviour
{
    string name;
    List<Task> playerTasks = new List<Task>();
    int affection;
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public void AddTask(Task task)
    {
        playerTasks.Add(task);
    }

    public void RemoveTask(Task task)
    {
        playerTasks.Remove(task);
    }
}
