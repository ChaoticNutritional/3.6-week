using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMove : MonoBehaviour
{
    [Header("Player's Movement Params")]
    public Vector3 direction;
    public float speed;

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

        direction.x = inputVector.x;
        direction.z = inputVector.y;
    }
}
