using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    bool completed;
    int affectionReward;
    public delegate void TaskDelegate();
    TaskDelegate onTalk;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetCompleted(bool completed)
    {
        this.completed = completed;
    }

    public bool IsCompleted()
    {
        return completed;
    }

}
