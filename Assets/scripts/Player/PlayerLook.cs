using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : PlayerMovement
{

    // ==== variables =====
    float mouseX;
    float mouseY;
    float xRotation = 0f;
    public float mouseSensitivity = 1500f;
    public Transform playerBody;


    // Start is called before the first frame update
    void Start()
    {
        // locks the cursor to screen, pretty self explanatory tbh
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    {
        MouseInput();
       
    }



    void MouseInput()
    {
        // setting our mouse floats to what unity is seeing from the mouse input
        mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // why is x set to mouseY? because when we look up or down we're actually rolling along the x axis.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 90f);

        // and when we look side to side, we're yawing along the y axis.
        playerBody.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
      
    }
}
