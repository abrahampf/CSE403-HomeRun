using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitch : MonoBehaviour
{
    // Strength of the force
    public float forceStrength = 10f;

    // Direction of the force
    public Vector3 forceDirection = new Vector3(0f, 0f, 1f); // Example: to the right

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Apply force when the game starts
        rb.AddForce(forceDirection.normalized * forceStrength, ForceMode.Impulse);
    }
}
