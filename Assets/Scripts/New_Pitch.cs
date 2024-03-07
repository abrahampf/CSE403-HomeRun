using System.Collections;
using UnityEngine;

public class New_Pitch
{
    private Rigidbody rb;
    private Vector3 forceDirection;
    private float forceStrength;

    private Vector3 initialPos;
    private bool continuousPitching  = false;

    private float increase = 0.25f;
    public void Initialize(Rigidbody rigidbody, Vector3 direction, float strength)
    {
        rb = rigidbody;
        forceDirection = direction;
        forceStrength = strength;
        initialPos = rb.transform.position;
    }

    public IEnumerator ContinuousPitching(float pitchDelay)
    {
        continuousPitching = true;

        while (continuousPitching)
        {
            ResetBall();
            // Calculate the direction vector towards the initial position
            // Vector3 directionToInitialPos = (initialPos - rb.transform.position).normalized;
            // forceDirection = directionToInitialPos;
            // Wait for the specified pitch delay
            yield return new WaitForSeconds(pitchDelay);

            forceStrength += increase;
            // Apply force when the delay is over
            rb.AddForce(-forceDirection.normalized * forceStrength, ForceMode.Impulse);
        }
    }

    public void StopContinuousPitching()
    {
        continuousPitching = false;
    }

    public void ResetBall()
    {
        Debug.Log("Reset Ball position");
        // Reset the ball's position and velocity (customize as needed)
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
         Debug.Log("Ball position after reset: " + rb.transform.position);
        rb.transform.position = initialPos;
         Debug.Log("Ball position after setting: " + rb.transform.position);
    }
}