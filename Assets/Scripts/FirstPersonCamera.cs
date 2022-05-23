using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCamera : MonoBehaviour
{
    //Camera attached to the player
    [Tooltip("The Camera attached to the player")]
    public Camera playerCam;

    //Container vars for the mouse delta values for each frame
    public float deltaX; //change in x value of mouse between frames
    public float deltaY; //change in y value of mouse between frames

    //Container vars for player's rotation around x and y axis
    public float xRot; //rotation around the x axis in degrees, meaning your mouse moving up or down (aka mouse movement in respect to the x playe
    public float yRot; //rotation around the y axis in degrees meaning your mouse movement in respect to the y plane (up)

    public float mouseSensitivity; 
    // Start is called before the first frame update
    void Start()
    {
        playerCam = Camera.main;
        //we can do this because we only have one camera in the scene.
        //otherwise we would do the GetComponentInChildren method to get our player's camera

        Cursor.visible = false; //hides the cursor


    }

    // Update is called once per frame
    void Update()
    {
        //keeps track of player's x and y rotation
        yRot = yWrapper(yRot + deltaX * mouseSensitivity * Time.deltaTime);
        xRot -= deltaY * mouseSensitivity * Time.deltaTime;

        //keeps the player's x rotation clamped to -90 and 90 degrees
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        //yRot = yWrapper(yRot);

        playerCam.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }

    //OnCameraLook event handler

    public void OnCameraLook(InputValue value) //unity is looking for this function
    {
        
        //TODO
        //Code to handle the event
        //Reads the mouse delta as a vector 2 (the x value being the delta in X, and the y value being the delta in y)
        Vector2 inputVector = value.Get<Vector2>(); //inputValue objects are part of the InputSystem API.
        deltaX = inputVector.x;
        deltaY = inputVector.y;
    }

    public float yWrapper(float yRot)
    {
        if(yRot >= 360 || yRot <= -360)
        {
            //Debug.Log("i've been summoned");
            return 0;
        }
        else
        {
            //Debug.Log("the rest");
            return yRot;
        }
    }
}
