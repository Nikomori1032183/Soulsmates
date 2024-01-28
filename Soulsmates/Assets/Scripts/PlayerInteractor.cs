using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using VInspector;


public class PlayerInteractor : MonoBehaviour
{
    //core
    public GameObject textBoxPrefab;
    public GameObject player;
    Lover lover;
    UnityEvent onInteract;
    TurnHandler onTurnHandler;


    //Interactables
    CollectableItem collectedItem;
    InteractLover interactLover;
    InteractLocation interactLocation;

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

    Sabotage sabotage;

    //Canvas
    [SerializeField] Canvas playerInteractCanvas;
    [SerializeField] Canvas playerGiveCanvas;
    [SerializeField] Canvas confrontCanvas;

    //[SerializeField] Animator doorAnimator;

    bool keyCollected = false;
    bool locked = true;
    int range = 4;
    [SerializeField] float followSpeed = 0.55f;

    bool inLeft;
    bool inRight;

    float probability;

    Vector3 offset = new Vector3(-1, 0, 0);
    Vector3 currentVelocity;

    void Start()
    {
        InputHandler.OnInteract += interact;
        InputHandler.OnDrop += DropItem;
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
            Debug.Log("A Lover is Near");
            InteractLover interact = other.GetComponent<InteractLover>();
            interactLover = interact;
        }

        //if (other.GetComponent<Location>() != null)
        //{
        //    Location place = other.GetComponent<Location>();
        //    locationReached = place;
        //}

        //if (other.GetComponent<People>() != null)
        //{
        //    Debug.Log("A random NPC is near");
        //    People person = other.GetComponent<People>();
        //    personConfronted = person;
        //}

        if(other.GetComponent<Sabotage>() != null)
        {
            Debug.Log("Sabotage Available");
            Sabotage sabo = other.GetComponent<Sabotage>();
            sabotage = sabo;
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
        if (interactLover != null)
        {
            //call default interact text with 2 buttons
            playerInteractCanvas.GameObject().SetActive(true);
            TextBox tb = Instantiate(textBoxPrefab, new Vector3(-960, -362.7f, 0), Quaternion.identity).GetComponent<TextBox>();
            //tb.SetDirectory("");
            interactLover = null;
        }

        if (personConfronted != null)
        {
            Confront();
        }

        if (sabotage != null)
        {
            OnSabotage();
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
    
    public void GiveItem()
    {
        playerInteractCanvas.GameObject().SetActive(false);
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

        //set UI Buttons for Give left and right to active
        playerGiveCanvas.GameObject().SetActive(true);
    }
    
    public void Escort()
    {
        playerInteractCanvas.GameObject().SetActive(false);
        bool lover = false;
        bool follow = false;

        Debug.Log("escort pressed for " + interactLover.lover.GetName());
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
            Debug.Log(interactLover.lover.GetName() + " is following Player");
            interactLover.GameObject().transform.position = Vector3.SmoothDamp(interactLover.GameObject().transform.position, player.transform.position + offset, ref currentVelocity, followSpeed);
        }

        //check if npc is at a location
        if(lover && escortTask.GetLocation() == charData.GetCurrentLocation())
        {
            Debug.Log("Lover has been escorted");
            escortTask.ChangeTaskStage(EscortTask.TaskStage.NPC_Escorted);
            follow = false;
            lover = false;
        }
        else if (charData.GetCurrentLocation() != null)
        {
            Debug.Log(interactLover.lover.GetName() + " has been dropped off at " + charData.GetCurrentLocation().locationName);
            follow = false;
        }
        //how will player drop npc off? just as a trigger for the npc????
    }

    private void Confront()
    {
        //locate another NPC and interact with speech

        //check that player has confront task with this player
        if (confrontTask.GetPerson() == personConfronted)
        {
            //activate/display buttons and text
            //Option A, B, C
            confrontCanvas.GameObject().SetActive(true);
        }
        else
        {
            Debug.Log("Cannot confront this person");
        }
        //if so confront 3 choices
        //instantiate text box that points to conversation folder
    }

    public void OptionA()
    {
        confrontCanvas.GameObject().SetActive(false);
        Debug.Log("plays says small insult");
        playerData.AddAffection(10);
    }

    public void OptionB()
    {
        confrontCanvas.GameObject().SetActive(false);
        Debug.Log("plays says medium insult");
        probability = 1f / 2f; //50 percent chance (a 1 in 2 chance)
        if (Random.Range(0f, 1f) <= probability)
        {
            playerData.AddAffection(20);
        }
    }

    public void OptionC()
    {
        confrontCanvas.GameObject().SetActive(false);
        Debug.Log("plays says large insult");
        probability = 1f / 10f; //10 percent chance (a 1 in 2 chance)
        if (Random.Range(0f, 1f) <= probability)
        {
            playerData.AddAffection(40);
        }
    }

    public void GiveLeft()
    {
        playerGiveCanvas.GameObject().SetActive(false);
        Debug.Log("Giving Left Item");
        ItemGiving = charData.GetLeftItem();
        ItemGive();
    }
    
    public void GiveRight()
    {
        playerGiveCanvas.GameObject().SetActive(false);
        Debug.Log("Giving Right Item");
        ItemGiving = charData.GetRightItem();
        ItemGive();
    }

    private void ItemGive()
    {
        //disable buttons

        if (fetchTask.GetItem() == ItemGiving)
        {
            Debug.Log("Fetch Task Complete");
            fetchTask.ChangeTaskStage(FetchTask.TaskStage.Item_Gifted);
            RemoveItem();
            playerData.AddAffection(20);
            TextBox tb = Instantiate(textBoxPrefab, new Vector3(-960, -362.7f, 0), Quaternion.identity).GetComponent<TextBox>();
            tb.SetDirectory(""); //Display retrieved liked item text
        }
        //check if item is liked or hated
        if (ItemGiving == lover.GetDislikedItem())
        {
            Debug.Log("Character Disliked the item, likeability went down");
            RemoveItem();
            playerData.RemoveAffection(10);
            TextBox tb = Instantiate(textBoxPrefab, new Vector3(-960, -362.7f, 0), Quaternion.identity).GetComponent<TextBox>();
            tb.SetDirectory("");
            //Display dislike text
        }
        else
        {
            Debug.Log("Character had no opinion for the item");
            RemoveItem();
            TextBox tb = Instantiate(textBoxPrefab, new Vector3(-960, -362.7f, 0), Quaternion.identity).GetComponent<TextBox>();
            tb.SetDirectory("");
            //display text for no opinion about item
        }
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

    private void OnSabotage()
    {

    }
}
