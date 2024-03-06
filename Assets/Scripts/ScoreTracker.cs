using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public GameObject ballObject;
    private BatterReference batterReference;
    private Vector3 fixedPoint;
    public static float score = 0; // The distance between original point (batter) and the ball when the ball touches the ground
                            // for the first time.
    public Bat batScript; // Reference to the script with the hasBeenBatted field

    private static bool scoreUpdated = false; // Flag to track whether the score has been updated

    void Start()
    {
        if (ballObject != null)
        {
            batterReference = ballObject.GetComponent<BatterReference>();
            fixedPoint = batterReference.referencePosition;
        }
        else
        {
            UnityEngine.Debug.LogError("Ball object is not assigned.");
        }
    }

    void Update()
    {
        // Calculate the distance between the ball and the fixed point when the ball's y-coordinate is <= 0.01.
        // y <= 0.01 is to register the score when the ball touches the ground, which using y <= 0 won't count
        // as ground has a notion of "thickness" making the ball unreachable to y = 0.

        // This is a temporary solution as it doesn't account for non-ground surfaces.
        if (!scoreUpdated && batScript.hasBeenBatted && ballObject.transform.position.y <= 0.05f)
        {
            // score = ballObject.transform.position.z - fixedPoint.z;
            score += 2;

            // Set the flag to true to indicate that the score has been updated
            scoreUpdated = true;
        }
    }

    // Provide a static method or property to access the score from other scripts
    public static float GetScore()
    {
        return score;
    }

    // Optionally, provide a method to reset the score, which can be called when restarting the game or under specific conditions
    public static void ResetScore()
    {
        score = 0;
        scoreUpdated = false;
    }
}
