using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Animation doorAnim;
    bool door = false;
    // Start is called before the first frame update
    private void Start()
    {
        doorAnim = GetComponentInParent<Animation>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && !door)
        {
            DoorPlayA();
        }
    }
    void DoorPlayA()
    {
        doorAnim.Play("doorOpen");
        door = true;
        Destroy(this);
    }
}