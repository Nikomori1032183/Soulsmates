using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNew : MonoBehaviour
{
    [SerializeField] float curSpeed;
    public float defSpeed;
    public float sprint;
    public Animation walkAnimator;

    // Start is called before the first frame update
    void Start()
    {
        walkAnimator = GetComponentInChildren<Animation>();
        walkAnimator.Play();
        InputHandler.OnForward += MoveForward;
        InputHandler.OnBackward += MoveBackward;
        InputHandler.OnLeft += MoveLeft;
        InputHandler.OnRight += MoveRight;
        InputHandler.OnSprint += MoveSprint;
        InputHandler.OnStopSprint += Walk;
    }

    // Update is called once per frame
    void Update()
    {
        if (curSpeed != 0)
        {
            walkAnimator.Play();
        }
        if (curSpeed == 0)
        {
            walkAnimator.Stop();
        }
    }

    private void MoveSprint()
    {
        curSpeed = sprint;
    }
    private void Walk()
    {
        curSpeed = defSpeed;
    }
    private void MoveForward()
    {
        transform.position += Vector3.forward * curSpeed * Time.deltaTime;
    }
    private void MoveBackward()
    {
        transform.position += Vector3.back * curSpeed * Time.deltaTime;
    }
    private void MoveLeft()
    {
        transform.position += Vector3.left * curSpeed * Time.deltaTime;
    }
    private void MoveRight()
    {
        transform.position += Vector3.right * curSpeed * Time.deltaTime;
    }

    IEnumerator WaitFive()
    {
        yield return new WaitForSeconds(5);
    }
}
