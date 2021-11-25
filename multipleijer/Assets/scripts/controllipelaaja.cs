using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class controllipelaaja : MonoBehaviour

{
    CharacterController Controller;
    public float moveSpeed = 16f;

    public float runSpeed = 32f;

    public float jumpHeight = 3f;

    public float gravity = -9f;

    public Transform groundCheck;

    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    public Animator animator;

    [SerializeField] private bool isGrounded;
    
    private Vector3 velocity;

    private Vector3 moveDir;

    //Korteks
    PhotonView Korteks;
    
        // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
        Korteks = GetComponent<PhotonView>();
    }

     // Update is called once per frame
     void Update()
    {
        if(Korteks.IsMine)
        {
            CheckIfGrounded();
            Mover();
            Jumpmoment();
        }
       
    }
    
    private void Jumpmoment()
    {
       if(Input.GetButtonDown("Jump") && isGrounded)
       {
          velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
          
       }
       velocity.y += gravity * Time.deltaTime;
       Controller.Move(velocity * Time.deltaTime);
    }


    private void CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        animator.SetBool("Ground",isGrounded);
        if(isGrounded)
        {
           velocity.y = -2;


        }

        velocity.y +=gravity * Time.deltaTime;
        Controller.Move(velocity * Time.deltaTime);
        
    }
// Note that I have beaten Splatoon 2 Hero Mode
    private void Mover()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        moveDir = transform.right * xAxis + transform.forward *zAxis;

        float targetSpeed = Input.GetButton("Fire1") ? runSpeed : moveSpeed;
        
        if(moveDir == Vector3.zero)
        {
         targetSpeed = 0;

        }
        // not the best way to do this but who gives a ****
        animator.SetFloat("Speed",targetSpeed);
        Controller.Move(moveDir * targetSpeed * Time.deltaTime);
    }
}
