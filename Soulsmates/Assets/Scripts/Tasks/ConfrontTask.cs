using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfrontTask : Task
{
    People people;

    TaskStage taskStage;

    public static event TaskDelegate OnNPCConfronted;

    public enum TaskStage
    {
        Start, NPC_Confronted
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void SetPerson(People person) //set requested item at begginning of turn
    {
        people = person;
    }

    public People GetPerson()
    {
        return people;
    }

    public void ChangeTaskStage(TaskStage stage)
    {
        taskStage = stage;

        switch (taskStage)
        {
            case TaskStage.NPC_Confronted:
                OnNPCConfronted?.Invoke();
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
