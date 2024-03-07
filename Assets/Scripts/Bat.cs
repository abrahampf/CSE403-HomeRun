using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public bool hasBeenBatted = false;
    public const float frontHittingBoundary = 2.0f;
    public const float backHittingBoundary = -2.0f;
    public const float centerHitZValue = 0.0f;
    public bool forceAdded = false;

    private BatterReference batterReference;

    void Start()
    {
        batterReference = GetComponents<BatterReference>()[0];
        if (batterReference == null)
        {
            UnityEngine.Debug.LogError("BatterReference not found!");
            return;
        }
    }


    /**
     * Method to bat the ball through mouse click
     *
     * @param ballContactZValue the relative delay of player's batting input to the earliest possible time to bat.
     *                Although the variable name is "time", the delay is computed based on baseball's z-axis
     *                coordinate (-(current z-value - smallest z-value that allows hitting), it is negative as
     *                the ball's absolute z-value decreases going from the pitcher to the batter).
     */
    public void BatBall()
    {
        if (BallIsInRange())
        {
            // hasBeenBatted = true; // Mark as batted to prevent multiple bat events

            float ballContactZValue = -transform.position.z + batterReference.referencePosition.z;

            // Exert a force to "bat" the ball back
            // Flip the direction of added force for realism
            // Use a 0.15 factor to allow a narrower angles of batting to decrease the high odds of out
            Vector3 delayedImpactForce = new Vector3(-0.15f * (ballContactZValue + centerHitZValue), 0, 0);
            // Vector3 delayedImpactForce = new Vector3(0, 0, 0);

            // Debug.Log("Force added to ball");
            GetComponent<Rigidbody>().AddForce((Vector3.back + delayedImpactForce) * -100f, ForceMode.Impulse);
            // Debug.Log("Force added to ball");
            forceAdded = true;
        } else {
            forceAdded = false;
        }
    }

    /**
     * Method to bat the ball through swipe
     *
     * @param ballContactZValue the relative delay of player's batting input to the earliest possible time to bat.
     *                Although the variable name is "time", the delay is computed based on baseball's z-axis
     *                coordinate (-(current z-value - smallest z-value that allows hitting), it is negative as
     *                the ball's absolute z-value decreases going from the pitcher to the batter).
     */
    public void BatBall(Vector2 swipeVector, float swingDuration)
    {
        if (!hasBeenBatted && BallIsInRange())
        {
            hasBeenBatted = true; // Mark as batted to prevent multiple bat events

            float ballContactZValue = -transform.position.z + batterReference.referencePosition.z;

            // UnityEngine.Debug.Log("Entered BatBall for swipe");
            // Exert a force to "bat" the ball back
            // Flip the direction of added force for realism
            // Use a 0.15 factor to allow a narrower angles of batting to decrease the high odds of out
            Vector3 forwardForce = new Vector3(0, 0, 50f);
            Vector3 verticalForce = new Vector3(0, 0.1f * swipeVector.y, 0);
            Vector3 delayedImpactForce = new Vector3(-0.15f * (ballContactZValue + centerHitZValue), 0, 0);
            float batForce = 0.0001f / swingDuration * swipeVector.magnitude;

            // UnityEngine.Debug.Log("verticalForce: " + verticalForce);
            // UnityEngine.Debug.Log("Combined force: " + ((forwardForce + delayedImpactForce + verticalForce) * batForce));

            GetComponent<Rigidbody>().AddForce((forwardForce + delayedImpactForce + verticalForce) * batForce, ForceMode.Impulse);
        }
    }

    private bool BallIsInRange()
    {
        Vector3 ballPosition = GetComponent<Rigidbody>().position;
        // Multiply the ball position by batterReference's direction to get the ball's z-value relative to the batter.
        float ballZValue = Vector3.Dot(ballPosition, batterReference.direction);
        if (ballZValue <= frontHittingBoundary + batterReference.referencePosition.z &&
            ballZValue >= backHittingBoundary + batterReference.referencePosition.z)
        {
            // UnityEngine.Debug.Log("Ball is in range");
            return true;
        }
        // UnityEngine.Debug.Log("Ball is not in range");
        return false;
    }
}