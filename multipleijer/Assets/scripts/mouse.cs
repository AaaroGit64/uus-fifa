using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;

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

    CinemachineVirtualCamera vcam;

    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = mode;
        playerBody = gameObject.transform.parent;
        view = playerBody.GetComponent<PhotonView>();
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(view.IsMine)
        {
            mouseX = Input.GetAxis("Mouse X") *mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") *mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation,minXangle,maxAngle);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);
        }
        
    }
}
