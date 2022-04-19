using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 9f;
    public float gravity = -9.81f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //this movemtn works with keyboards and controllers
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            print("jumped");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
