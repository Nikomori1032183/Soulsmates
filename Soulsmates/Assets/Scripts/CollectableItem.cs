using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectableItem : MonoBehaviour
{
    public Item item;
    public UnityEvent onInteract;

    //interactable
    public interface InteractableInterface
    {
        public bool Interact(PlayerInteractor interactor);
    }
}
