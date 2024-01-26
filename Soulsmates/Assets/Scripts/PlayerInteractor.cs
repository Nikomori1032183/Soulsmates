using System.Collections;
using System.Collections.Generic;
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
    //[SerializeField] Animator doorAnimator;

    public bool keyCollected = false;
    public bool locked = true;
    public int range = 4;

    void Start()
    {
        InputHandler.OnInteract += interact;
        charData = GetComponent<CharacterData>();
    }

    private void OnTriggerEnter(Collider other)
    {
        CollectableItem collect = other.GetComponent<CollectableItem>();
        Debug.Log("Collectable Object In Range");
        collectedItem = collect;
        
    }

    private void interact()
    {
        if (collectedItem != null)
        {
            if (charData.GetLeftItem() == null)
            {
                charData.SetLeftItem(collectedItem.item);
                Debug.Log(collectedItem.item.itemName + " was added to inventory");
            }
            else if (charData.GetRightItem() == null)
            {
                charData.SetRightItem(collectedItem.item);
                Debug.Log(collectedItem.item.itemName + " was added to inventory");
            }
            else
            {
                Debug.Log("Hands are full, cannot pick up item");
            }
        }
    }
}
