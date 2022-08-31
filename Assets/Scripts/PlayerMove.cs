using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;

    public float maxEnergy;
    public float currentEnergy;
    public Slider energySlider;

    //Movement
    public float speed;
    public float runspeed = 24f;
    public float walkspeed = 12f;


    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    void Start()
    {
        currentEnergy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        
        Vector3 move = transform.right * x + transform.forward * z;
        
        controller.Move(move * speed * Time.deltaTime);
        move = move.normalized * speed;

        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runspeed;
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
