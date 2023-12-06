using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    public float gravity = -9.81f;

    public Vector3 velocity;
    private bool isGrounded;
    private bool isPlayerLocked = false;


    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    

    public void LockPlayer()
    {
        isPlayerLocked = true;
        velocity = new Vector3(0, 0, 0);
    }

    public void UnlockPlayer()
    {
        isPlayerLocked = false;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0 && !isPlayerLocked)
        {
            velocity.y = -2f;
        }

        if (!isPlayerLocked)
        {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

        }
    }
}
