using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public bool hasBeenBatted = false;

    /**
     * Method to bat the ball through mouse click
     * 
     * @param ballContactZValue the relative delay of player's batting input to the earliest possible time to bat.
     *                Although the variable name is "time", the delay is computed based on baseball's z-axis
     *                coordinate (-(current z-value - smallest z-value that allows hitting), it is negative as
     *                the ball's absolute z-value decreases going from the pitcher to the batter).
     */
    public void BatBall(float ballContactZValue)
    {
        if (!hasBeenBatted)
        {
            hasBeenBatted = true; // Mark as batted to prevent multiple bat events

            // Exert a force to "bat" the ball back
            // Flip the direction of added force for realism
            // Use a 0.15 factor to allow a narrower angles of batting to decrease the high odds of out
            Vector3 delayedImpactForce = new Vector3(-0.15f * (ballContactZValue + BattingInputManager.centerHitZValue), 0, 0);

            GetComponent<Rigidbody>().AddForce((Vector3.back + delayedImpactForce) * -100f, ForceMode.Impulse);
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
    public void BatBall(float ballContactZValue, Vector2 swipeVector, float swingDuration)
    {
        if (!hasBeenBatted)
        {
            hasBeenBatted = true; // Mark as batted to prevent multiple bat events
            UnityEngine.Debug.Log("Entered BatBall for swipe");
            // Exert a force to "bat" the ball back
            // Flip the direction of added force for realism
            // Use a 0.15 factor to allow a narrower angles of batting to decrease the high odds of out
            Vector3 forwardForce = new Vector3(0, 0, 50f);
            Vector3 verticalForce = new Vector3(0, 0.1f * swipeVector.y, 0);
            Vector3 delayedImpactForce = new Vector3(-0.15f * (ballContactZValue + BattingInputManager.centerHitZValue), 0, 0);
            float batForce = 0.0001f / swingDuration * swipeVector.magnitude;

            // UnityEngine.Debug.Log("verticalForce: " + verticalForce);
            UnityEngine.Debug.Log("Combined force: " + ((forwardForce + delayedImpactForce + verticalForce) * batForce));

            GetComponent<Rigidbody>().AddForce((forwardForce + delayedImpactForce + verticalForce) * batForce, ForceMode.Impulse);
        }
    }
}
