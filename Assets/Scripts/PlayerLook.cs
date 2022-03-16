using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is provides the player with camera movement when the player moves their mouse
//this script is largely based upon this tutorial: https://www.youtube.com/watch?v=_QajrabyTJc
public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 5f;
    public Transform playerBody;

    float rotationX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("sensitivity",5);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        //this is so the player body rotates when the user moves the camera with the mouse
        playerBody.Rotate(Vector3.up * mouseX);
    }
}