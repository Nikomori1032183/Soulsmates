using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Frank Manford
// Description: Class for holding player data

public class PlayerData : MonoBehaviour
{
    string playerName;
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

    public void ResetTasks()
    {
        playerTasks.Clear();
    }

    public Lover GetLover()
    {
        return lover;
    }

    public void AddAffection(int love)
    {
        this.affection += love;
    }

    public void RemoveAffection(int love)
    {
        this.affection -= love;
    }

    public int GetAffection()
    {
        return affection;
    }

    public void SetLover(Lover lover)
    {
        this.lover = lover;
    }
}