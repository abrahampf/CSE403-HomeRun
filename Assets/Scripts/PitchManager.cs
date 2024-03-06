using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PitchManger : MonoBehaviour
{
    // Strength of the force
    public float forceStrength = 5f;

    // Direction of the force
    public Vector3 forceDirection = new Vector3(0f, 0f, 1f); // Example: to the right

    public float pitchDelay = 2f;

    public New_Pitch pitch;

    public bool isBallThrown = false;

    public Bat bat; // Reference to the Bat script
    public static int strikes = 0;
    public int maxStrikes = 4;
    public static int curr_score = 0;


    void Start()
    {
        pitch = new New_Pitch();
        pitch.Initialize(GetComponent<Rigidbody>(), forceDirection, forceStrength);

        /// Start the coroutine for the pitch delay
        StartCoroutine(pitch.ContinuousPitching(pitchDelay));
    }

     void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (bat != null)
            {
                bat.BatBall();
                if (!bat.forceAdded) {
                    IncrementStrikes();
                } else {
                    curr_score += 2;
                }
            }
            else
            {
                UnityEngine.Debug.LogError("Bat reference not set in InputManager!");
            }
        }
    }

    void IncrementStrikes()
    {
        // Increment the strikes count
        strikes++;

        // Check for game over
        if (strikes >= maxStrikes)
        {
            pitch.StopContinuousPitching();
            DBManager.currentScore = curr_score;
            // Not able to update highscore for a user that is already signed in
            // Need to fix
            // DbCalls.CallUpdate();
            Reset();
            CallGameOver();
        }
    }

    public static int Get_strikes() {
        return strikes;
    }

    public static int Get_Score() {
        return curr_score;
    }

    void Reset()
    {
        // Reset the strikes count
        strikes = 0;
        curr_score = 0;
    }
    void CallGameOver() {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        if (DBManager.loggedIn()) {
            SceneManager.LoadScene("GameOver");
        } else {
            SceneManager.LoadScene("GameOver2");
        }
    }
}
