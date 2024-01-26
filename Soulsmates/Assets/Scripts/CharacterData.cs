using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

// Author: Frank Manford
// Description: Class for storing character data

public class CharacterData : MonoBehaviour
{
    Item leftHand, rightHand;
    int coins;
    List<Status> statuses = new List<Status>();
    float speedMod;

    void Start()
    {

    }

    void Update()
    {

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

    public void AddStatus(Status status)
    {
        statuses.Add(status);
    }

    public void RemoveStatus(Status status)
    {
        statuses.Remove(status);
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