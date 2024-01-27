using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using VInspector;


public class PlayerInteractor : MonoBehaviour
{
    //core
    public GameObject player;
    Lover lover;
    UnityEvent onInteract;
    TurnHandler onTurnHandler;

    //Interactables
    CollectableItem collectedItem;
    InteractLover interactLover;

    //Data
    CharacterData charData;
    PlayerData playerData;

    //Tasks
    FetchTask fetchTask;
    EscortTask escortTask;
    ConfrontTask confrontTask;

    //ScriptableObjects
    Item ItemGiving;
    Location locationReached;
    People personConfronted;
    LovePerson LovePerson;

    //[SerializeField] Animator doorAnimator;

    bool keyCollected = false;
    bool locked = true;
    int range = 4;
    [SerializeField] float followSpeed = 0.55f;

    bool people;
    bool inLeft;
    bool inRight;

    Vector3 offset = new Vector3(-1, 0, 0);
    Vector3 currentVelocity;

    void Start()
    {
        InputHandler.OnInteract += interact;
        InputHandler.OnDrop += DropItem;
        charData = GetComponent<CharacterData>();
    }

    private void LateUpdate()
    {
        if (interactLover != null) //later change to when follow is true
        {
            //interactLover.GameObject().transform.position = player.transform.position + offset;
            
        }
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
            Debug.Log("A Lover is Near");
            InteractLover interact = other.GetComponent<InteractLover>();
            interactLover = interact;
            Debug.Log(interactLover.lovePerson.loverName);
        }

        //if (other.GetComponent<Location>() != null)
        //{
        //    Location place = other.GetComponent<Location>();
        //    locationReached = place;
        //}

        //if (other.GetComponent<People>())
        //{

        //    people = true;
        //}
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
        if (locationReached != null)
        {
            //call default interact text with 2 buttons
            //GiveItem();
            //Escort();
            locationReached = null;
        }

        if (people)
        {
            Confront();
            people = false;
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
    [Button]
    private void GiveItem()
    {
        if (charData.GetLeftItem() != null)
        {
            inLeft = true;
        }
        if (charData.GetRightItem() != null)
        {
            inRight = true;
        }
        if (charData.GetLeftItem() == null && charData.GetRightItem() == null)
        {
            Debug.Log("No items to give");
            return;
        }

        //move give left and right stuff into the functions and wait till selected to continue with rest of code

        //choose an item to give
        if (GiveLeft()) //push button for give left
        {
            Debug.Log("Giving Left Item");
            ItemGiving = charData.GetLeftItem();
        }
        if (GiveRight()) //push button for give right
        {
            Debug.Log("Giving Right Item");
            ItemGiving = charData.GetRightItem();
        }

        //rest of code

        if (fetchTask.GetItem() == ItemGiving)
        {
            Debug.Log("Fetch Task Complete");
            fetchTask.ChangeTaskStage(FetchTask.TaskStage.Item_Gifted);
            RemoveItem();
        }
        //check if item is liked or hated
        if (ItemGiving == lover.GetDislikedItem())
        {
            Debug.Log("Character Disliked the item, likeability went down");
            RemoveItem();
            //decrease playerData likeability
            //Display dislike text
        }
        else
        {
            Debug.Log("Character had no opinion for the item");
            RemoveItem();
            //display text for no opinion about item
        }

    }
    [Button]
    private void Escort()
    {
        bool lover = false; //a bool to see if player has their lover
        bool follow = false;

        Debug.Log("escort pressed for " + interactLover.lovePerson.loverName);
        //check if the player has the escort task for the lover to be escorted to
        if (onTurnHandler.GetPlayer().GetLover() == interactLover) //target lover VS interacting lover
        {
            Debug.Log("Lover has been collected");
            escortTask.ChangeTaskStage(EscortTask.TaskStage.NPC_Collected);
            lover = true;
            follow = true;
        }
        else
        {
            Debug.Log("Character collected");
            follow = true;
        }

        //follow system 
        if (follow)
        {
            Debug.Log(interactLover.lovePerson.loverName + " is following Player");
            interactLover.GameObject().transform.position = Vector3.SmoothDamp(interactLover.GameObject().transform.position, player.transform.position + offset, ref currentVelocity, followSpeed);
        }

        //bring NPC to location for location task
        if(lover && escortTask.GetLocation() == playerData.GetCurrentLocation())
        {
            Debug.Log("Lover has been escorted");
            escortTask.ChangeTaskStage(EscortTask.TaskStage.NPC_Escorted);
            follow = false;
            lover = false;
        }
        else if (playerData.GetCurrentLocation() != null)
        {
            Debug.Log(interactLover.lovePerson.loverName + " has been dropped off at " + playerData.GetCurrentLocation().locationName);
            follow = false;
        }
        //how will player drop npc off? just as a trigger for the npc????
    }

    private void Confront()
    {
        //locate another NPC and interact with speech

        //check that player has confront task with this player

        //if so confront 3 choices
        //instantiate text box that points to conversation folder
    }
    [Button]
    private bool GiveLeft()
    {
        return true;
    }
    [Button]
    private bool GiveRight()
    {
        return true;
    }

    private void RemoveItem()
    {
        if (inLeft)
        {
            charData.SetLeftItem(null);
            inLeft = false;
        }
        else
        {
            charData.SetRightItem(null);
            inRight = false;
        }
    }
}
