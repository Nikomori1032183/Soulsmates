using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatingSystem : MonoBehaviour
{
    PlayerData playerData;
    List<Task> taskList = new List<Task>();
    

    // Start is called before the first frame update
    void Start()
    {
        playerData = GetComponent<PlayerData>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //be able to say which category of task **************
    //system grabs the task from that category
    //returns it to CURRENT player data (get playerName)
    //adds to the players task list
    //loops till all task types are done
    //loops till all players are done

    void RandomTask(Task.TaskDelegate type) //when we call for a random task for a retrieve task
    {


    }
}
