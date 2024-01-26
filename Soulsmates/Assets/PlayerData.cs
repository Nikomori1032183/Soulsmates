using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Frank Manford
// Description: Class for storing player data

public class PlayerData : MonoBehaviour
{
    Item leftHand, rightHand;
    string name;
    int coins;
    List<Status> statuses = new List<Status>();
    float speedMod;
    List<Task> tasks = new List<Task>();
 
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

    public void SetCoins(int coins)
    {
        this.coins = coins;
    }

    public void SetSpeedMod(float speedMod)
    {
        this.speedMod = speedMod;
    }

    public void SetLeftItem(Item item)
    {
        leftHand = item;
    }

    public void SetRightItem(Item item)
    {
        rightHand = item;
    }

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    public void AddStatus(Status status)
    {
        statuses.Add(status);
    }

    public void RemoveTask(Task task)
    {
        tasks.Remove(task);
    }

    public void RemoveStatus(Status status)
    {
        statuses.Remove(status);
    }

    public string GetName()
    {
        return name;
    }

    public Item GetLeftItem()
    {
        return leftHand;
    }

    public Item GetRightItem()
    {
        return leftHand;
    }
}