using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //set up mouseSensitive
    public float mouseSensitive = 100f;

    //set up Body
    public Transform playBody;

    //Don't rotate
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Lock CurserMouse
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //GetAxis command Input manager
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitive * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitive * Time.deltaTime;

        //Makes the object move along the mouse Y axis.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
      
        //Makes the object move along the mouse X axis.
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        playBody.Rotate(Vector3.up * mouseX);
    }
}
