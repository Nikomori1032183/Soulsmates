using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchTask : Task
{
    Item requrestedItem;

    TaskStage taskStage;

    public static event TaskDelegate OnItemCollected;

    public enum TaskStage
    {
        Start, Item_Collected, Item_Gifted
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void SetItem(Item item)
    {
        requrestedItem = item;
    }

    public Item GetItem()
    {
        return requrestedItem;
    }

    public void ChangeTaskStage(TaskStage stage)
    {
        taskStage = stage;

        switch(taskStage)
        {
            case TaskStage.Item_Collected:
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