using System.Collections;
using System.Collections.Generic;
using UnityEngine;

CharacterController Controller : MonoBehaviour

public float moveSpeed = 16F;

public float runSpeed = 99F;

public float jumpHeight 3F;

public float gravity = -9F;

public Transform groundCheck;

public float groundDistance = 0.1f;
public LayerMask groundMask;

[SerializeField] private bool isGrounded;

public class controllipelaaja : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
