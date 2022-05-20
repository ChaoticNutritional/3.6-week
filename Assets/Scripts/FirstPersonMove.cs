using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMove : MonoBehaviour
{
    [Header("Player's Movement Params")]
    public Vector3 direction; //player's direction, only Vector3 because it's build in
    public float speed; //speed that we set

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void OnPlayerMove(InputValue value)
    {
        //Vector with X and Y components corresponding to the player's WASD or Arrow Key inputs
        // both components in range [-1, 1]
        Vector2 inputVector = value.Get<Vector2>();
        //direction = new Vector3(inputVector.x, 0, inputVector.y);

        direction.x = inputVector.x; //x value of 2d vector created in input manager
        direction.z = inputVector.y; //y value of 2d vector created in input manager
        //two components of 2D vector mapped to the horizontal plane axes in a 3D vector (x,z)
        //ignoring y because player does not move along the vertical axis.
    }
}
