using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CollectableItem : ScriptableObject
{
    public string itemName;
    public int ID;

    public interface InteractableInterface
    {
        //public bool Interact(Interactor interactor);
    }
}
