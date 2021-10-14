using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    public float mouseSensitivity = 250;
    public float minXangle = -80f;
    public float maxAngle = 90f;

    Transform playerBody;
    private float mouseX;
    private float mouseY;

    private float xRotation = 0f;
    public CursorLockMode mode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
