using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class PlayerInteractor : MonoBehaviour
{
    GameObject player;
    UnityEvent onInteract;
    CollectableItem collectedItem;
    CharacterData charData;
    FetchTask fetchTask;
    //[SerializeField] Animator doorAnimator;

    bool keyCollected = false;
    bool locked = true;
    int range = 4;
    bool NPC;

    void Start()
    {
        InputHandler.OnInteract += interact;
        InputHandler.OnInteract += DropItem;
        charData = GetComponent<CharacterData>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if object in range is a collectable item
        if (other.GetComponent<CollectableItem>() != null)
        {
            CollectableItem collect = other.GetComponent<CollectableItem>();
            Debug.Log("Collectable Object In Range");
            collectedItem = collect;
        }
        //if object in range is an NPC with NPC tag
        if (other.GameObject().CompareTag("NPC"))
        {
            NPC = true;
        }
    }

    //.onInteract.Invoke();
    // CALL by -> instantiate text box that points to conversation folder

    private void interact()
    {
        if (collectedItem != null)
        {
            CollectItem();
        }

        //if interacting with a NPC
        if (NPC)
        {
            //call default interact text with 3 buttons
            GiveItem();
            Escort();
            Confront();
        }
        

    }

    private void DropItem()
    {
        if (charData.GetLeftItem() != null)
        {
            charData.RemoveItem();
        }
        else
        {
            Debug.Log("No items in hand to drop");
        }
    }

    private void CollectItem()
    {
        if (collectedItem != null)
        {
            if (charData.GetLeftItem() == null)
            {
                charData.SetLeftItem(collectedItem.item);
                Debug.Log(collectedItem.item.itemName + " was added to left hand");
            }
            else if (charData.GetRightItem() == null)
            {
                charData.SetRightItem(collectedItem.item);
                Debug.Log(collectedItem.item.itemName + " was added to right hand");
            }
            else
            {
                Debug.Log("Hands are full, cannot pick up item");
            }
        }
        collectedItem = null;
    }

    private void GiveItem()
    {
        //call give item text
        //check if player has item that their character wants (FetchTask.GetItem)
        if (fetchTask.GetItem() == charData.GetLeftItem() || fetchTask.GetItem() == charData.GetRightItem())
        {

        }
        //set item as being collected (set change task stage to 2)
        //if so give NPC item
        //call reaction to item 

    }

    private void Escort()
    {
        //call escort request text
        //follow system
        //bring NPC to location for location task
    }

    private void Confront()
    {
        //locate another NPC and interact with speech
        //confront 3 choices
        //instantiate text box that points to conversation folder
    }
}
