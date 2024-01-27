using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscortTask : Task
{
    Location location;

    TaskStage taskStage;

    public static event TaskDelegate OnNPCCollected;

    public enum TaskStage
    {
        Start, NPC_Collected, NPC_Escorted
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void SetLocation(Location item) //set requested item at begginning of turn
    {
        location = item;
    }

    public Location GetItem()
    {
        return location;
    }

    public void ChangeTaskStage(TaskStage stage)
    {
        taskStage = stage;

        switch (taskStage)
        {
            case TaskStage.NPC_Collected:
                OnNPCCollected?.Invoke();
                break;

            case TaskStage.NPC_Escorted:

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
