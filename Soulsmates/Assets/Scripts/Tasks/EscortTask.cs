using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscortTask : Task
{
    Item location; //location

    TaskStage taskStage;

    public static event TaskDelegate OnItemCollected;

    public enum TaskStage
    {
        Start, NPC_Connected, Item_Gifted
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void SetLocation(Item item) //set requested item at begginning of turn
    {
        location = item;
    }

    public Item GetItem()
    {
        return location;
    }

    public void ChangeTaskStage(TaskStage stage)
    {
        taskStage = stage;

        switch (taskStage)
        {
            case TaskStage.NPC_Connected:
                OnItemCollected?.Invoke();
                break;

            case TaskStage.Item_Gifted:

                break;

            default:
                break;
        }
    }

    public TaskStage GetTaskStage()
    {
        return taskStage;
    }
}
