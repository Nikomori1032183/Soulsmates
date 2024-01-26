using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    CharacterController charController;
    public Camera playerCam;

    Vector3 velocity;

    public float defSpeed = 10.0f;
    public float speed = 10.0f;
    public float jumpHeight = 2.0f;
    public float sprint = 20.0f;
    public float camSpeed = 2.0f;
    public float yaw;
    public float pitch;
    public bool isGrounded;

    //
    private void Awake()
    {
        //get the rigidbody from the player
        rb = GetComponent<Rigidbody>();
        //get the character controller from the player
        charController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //lock the cursor to the game
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Getting the user input for x and y
        float xMov = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float yMov = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 move = transform.right * xMov + transform.forward * yMov;

        //camera movement
        yaw += camSpeed * Input.GetAxis("Mouse X");
        pitch -= camSpeed * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -100, 90); //limits rotation of camera
        if (playerCam != null)
        {
            playerCam.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }

        //movement
        charController.Move(move);
        transform.eulerAngles = new Vector3(0.0f, pitch, 0.0f); //rotate player with mouse

        //sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = sprint;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = defSpeed;
        }

        //escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //return control to the cursor
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
