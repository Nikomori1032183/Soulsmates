using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNew : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.forward;
        }
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward;
    }
    private void MoveBackward()
    {
        transform.position -= Vector3.back;
    }
    private void MoveLeft()
    {
        transform.position = Vector3.left;
    }
    private void MoveRight()
    {
        transform.position = Vector3.right;
    }
}
