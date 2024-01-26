using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class PlayerInteractor : MonoBehaviour
{
    GameObject player;
    UnityEvent onInteract;
    CollectableItem interactable;
    //[SerializeField] Animator doorAnimator;

    public bool keyCollected = false;
    public bool locked = true;
    public int range = 4;



    private void Start()
    {
        
    }

    void Update()
    {
        //Player interacts with objects by entering radius and clicking interact


        


        //float distance = Vector3.Distance(GetComponent<CollectableItem>().gameObject.transform.position, transform.position);

        /*if(distance >= range)
        {
            Debug.Log("Collectable Object In Range");
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.onInteract.Invoke();
            }
        }*/
        

        //Player interacts with door by collecting key and interacting with the door

        /*
        player = GameObject.FindGameObjectWithTag("Player");

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (!locked && distance <= range && doorAnimator.GetBool("Close"))
        {
            doorAnimator.SetBool("Close", false);
            doorAnimator.SetBool("Open", true);

        }
        if (!locked && distance >= range && doorAnimator.GetBool("Open"))
        {
            doorAnimator.SetBool("Open", false);
            doorAnimator.SetBool("Close", true);
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        CollectableItem collect = other.GetComponent<CollectableItem>();

        if (collect != null)
        {
            Debug.Log("not null");
        }
        else
        {
            Debug.Log("null");
        }
        
    }

    /*
    public void Unlock()
    {
        if (keyCollected)
        {
            locked = false;
            Debug.Log("Door Unlocked"); //replace with pop up
        }
        else
        {
            Debug.Log("Key Needed"); //replace with pop up
        }
    }
    */

}
