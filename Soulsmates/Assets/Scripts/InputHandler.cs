using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public delegate void InputDelegate();

    [SerializeField] private KeyCode forward;
    [SerializeField] private KeyCode backward;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode interact;
    [SerializeField] private KeyCode sprint;
    [SerializeField] private KeyCode exit;
    [SerializeField] private KeyCode drop;

    public static event InputDelegate OnForward;
    public static event InputDelegate OnBackward;
    public static event InputDelegate OnLeft;
    public static event InputDelegate OnRight;
    public static event InputDelegate OnInteract;
    public static event InputDelegate OnSprint;
    public static event InputDelegate OnStopSprint;
    public static event InputDelegate OnExit;
    public static event InputDelegate OnDrop;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(forward))
        {
            //Debug.Log("Foward");
            OnForward?.Invoke();
        }

        if (Input.GetKey(backward))
        {
            //Debug.Log("Backward");
            OnBackward?.Invoke();
        }

        if (Input.GetKey(left))
        {
            //Debug.Log("Left");
            OnLeft?.Invoke();
        }

        if (Input.GetKey(right))
        {
            //Debug.Log("Right");
            OnRight?.Invoke();
        }

        if (Input.GetKeyDown(interact))
        {
            //Debug.Log("Interact");
            OnInteract?.Invoke();
        }

        if (Input.GetKeyDown(sprint))
        {
            //Debug.Log("Sprint");
            OnSprint?.Invoke();
        }

        if (Input.GetKeyUp(sprint))
        {
            //Debug.Log("Stop Sprint");
            OnStopSprint?.Invoke();
        }

        if (Input.GetKeyDown(exit))
        {
            //Debug.Log("Exit");
            OnExit?.Invoke();
        }

        if (Input.GetKeyDown(drop))
        {
            //Debug.Log("Drop");
            OnDrop?.Invoke();
        }
    }
}
