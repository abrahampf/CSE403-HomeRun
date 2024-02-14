using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public GameObject ballObject;
    public Vector3 fixedPoint = new Vector3(0f, 0f, -4f); // The fixed point from which the distance will be calculated
    public float score = 0; // The distance between original point (batter) and the ball when the ball touches the ground
                            // for the first time.
    public Bat batScript; // Reference to the script with the hasBeenBatted field

    private bool scoreUpdated = false; // Flag to track whether the score has been updated

    void Start()
    {
        // Get the GameObject with the Rigidbody component
        if (ballObject == null)
        {
            UnityEngine.Debug.LogError("Ball GameObject is not assigned in the inspector.");
        }
    }

    void Update()
    {
        // Calculate the distance between the ball and the fixed point when the ball's y-coordinate is <= 0.01.
        // y <= 0.01 is to register the score when the ball touches the ground, which using y <= 0 won't count
        // as ground has a notion of "thickness" making the ball unreachable to y = 0.
        if (!scoreUpdated && batScript.hasBeenBatted && ballObject.transform.position.y <= 0.05f)
        {
            score = ballObject.transform.position.z - fixedPoint.z;

            // Set the flag to true to indicate that the score has been updated
            scoreUpdated = true;
        }
    }
}
