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
    CharacterData charData;
    //[SerializeField] Animator doorAnimator;

    public bool keyCollected = false;
    public bool locked = true;
    public int range = 4;

    void Update()
    {
        //check left hand for item
        //if not add into left hand
        //check right hand
        //if not add into right hand
        //else debug cant pick up
    }

    private void OnTriggerEnter(Collider other)
    {
        CollectableItem collect = other.GetComponent<CollectableItem>();
        Debug.Log("Collectable Object In Range");
        if (collect != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (charData.GetLeftItem() == null)
                {
                    charData.SetLeftItem(collect.item);
                    Debug.Log(collect.item.itemName + "was added to inventory");
                }
                else if (charData.GetRightItem() == null)
                {
                    charData.SetRightItem(collect.item);
                    Debug.Log(collect.item.itemName + "was added to inventory");
                }
                else
                {
                    Debug.Log("Hands are full, cannot pick up item");
                }
            }
        }
    }


}
