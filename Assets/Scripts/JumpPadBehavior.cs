using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadBehavior : MonoBehaviour
{
    public float jumpForce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            rb.AddForce(other.transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}
