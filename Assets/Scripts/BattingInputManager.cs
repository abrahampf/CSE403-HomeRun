using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BattingInputManager : MonoBehaviour
{
    // public const float frontHittingBoundary = -1.75f;
    // public const float backHittingBoundary = -5.25f;
    // public const float centerHitZValue = (frontHittingBoundary + backHittingBoundary) / 2;

    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;
    public Vector2 swipeVector;

    private float touchStartTime;
    private float touchEndTime;
    public float swingDuration;

    // private float minSwipeDistance = 0f;

    // private bool firstStationary = true;

    public Bat bat; // Reference to the Bat script

    public static BattingInputManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            /*
            // Check if the ball is within the specified z-value range
            if (IsBallInRange())
            {
                // Call the BatBall method when mouse click is detected and ball is within range
                if (bat != null)
                {
                    float ballContactZValue = -bat.transform.position.z;
                    bat.BatBall(ballContactZValue);
                }
                else
                {
                    UnityEngine.Debug.LogError("Bat reference not set in InputManager!");
                }
            }
            */
            if (bat != null)
            {
                bat.BatBall();
            }
            else
            {
                UnityEngine.Debug.LogError("Bat reference not set in BattingInputManager!");
            }
        }
        /*
        if (Input.touchCount > 0) // Check if there is at least one touch
        {
            Touch touch = Input.GetTouch(0);

            // UnityEngine.Debug.Log("Touch phase: " + touch.phase.ToString());

            switch (touch.phase)
            {
                // TouchPhase.Began is extremely unreliable. It is never detected at least for playmode in Unity.
                // The first instance of TouchPhase.Stationary will be used instead.
                case TouchPhase.Stationary:
                    if (firstStationary) // This replaces the && condition in the switch case
                    {
                        UnityEngine.Debug.Log("isFirstStationary: " + firstStationary);
                        firstStationary = false; // Ensure this is the only place you set it to false
                        UnityEngine.Debug.Log("isFirstStationary: " + firstStationary);
                        touchStartPosition = touch.position;
                        // UnityEngine.Debug.Log("touchStartPosition: " + touchStartPosition);
                        touchStartTime = Time.time;
                    }
                    break;

                case TouchPhase.Ended:
                    touchEndPosition = touch.position;
                    // UnityEngine.Debug.Log("touchEndPosition: " + touchEndPosition);
                    touchEndTime = Time.time;
                    swipeVector = touchEndPosition - touchStartPosition;
                    swingDuration = touchEndTime - touchStartTime;
                    if (IsBallInRange())
                    {
                        UnityEngine.Debug.Log("The ball is in range");
                        DetectSwipe();
                    }
                    firstStationary = true;
                    UnityEngine.Debug.Log("isFirstStationary: " + firstStationary);
                    break;
            }
        }
        */
    }

    /*
    private void DetectSwipe()
    {
        // Check if the swipe is long enough to be considered a swipe
        if (Vector2.Distance(touchStartPosition, touchEndPosition) >= minSwipeDistance) 
        {
            UnityEngine.Debug.Log("Entered DetectSwipe");
            
            // Here you can add additional logic to determine the direction of the swipe
            // and adjust the bat swing strength or direction accordingly.

            if (bat != null)
            {
                float ballContactZValue = -bat.transform.position.z;
                bat.BatBall(ballContactZValue, swipeVector, swingDuration);
            }
            else
            {
                UnityEngine.Debug.LogError("Bat reference not set in BattingInputManager!");
            }
        }
    }
    */

    /*
    // Check if the ball is within the specified z-value range
    bool IsBallInRange()
    {
        float ballZ = bat.transform.position.z; // Get the z-position of the ball
        return ballZ > backHittingBoundary && ballZ < frontHittingBoundary; // Check if the z-value falls within the range
    }
    */
}