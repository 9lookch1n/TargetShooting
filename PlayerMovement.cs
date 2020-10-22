using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //FPSController

    //set up CharacterController
    public CharacterController controller;

    //set up speed
    public float speed = 12f;
    //set up gravity
    public float gravity = -9.81f;
    //Limit jumpHigh
    public float jumpHigh = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    //set up vector3
    Vector3 velocity;
    //bool checkGround
    bool isGround;

    // Update is called once per frame
    void Update()
    {
        //Use Physics for check ground with player
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //When jump
        if (isGround && velocity.y < 0)
        {
            //Vector3
            velocity.y = -2f;
        }


        //GetAxis command Input manager
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        //Move speed / Time
        controller.Move(move * speed * Time.deltaTime);

        //Jump
        if (Input.GetButtonDown("Jump") && isGround)
        {
            //Vector3 use Math Equal = Jump + gravity
            velocity.y = Mathf.Sqrt(jumpHigh * -2f * gravity);
        }

        //velocity Y + gravity
        velocity.y += gravity * Time.deltaTime;
        //Ctrl Vector3
        controller.Move(velocity * Time.deltaTime);
    }
}
