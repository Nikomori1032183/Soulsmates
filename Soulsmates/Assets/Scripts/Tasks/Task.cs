using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    bool completed;
    public delegate void TaskDelegate();

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