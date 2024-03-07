using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using JetBrains.Annotations;
using UnityEngine.Networking;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.EventSystems;

public class PitchManager : MonoBehaviour
{
    // Strength of the force
    public float forceStrength = 2f;

    // Direction of the force
    public Vector3 forceDirection = new Vector3(0f, 0f, 1f); // Example: to the right

    public float pitchDelay = 2f;

    public New_Pitch pitch;

    public bool isBallThrown = false;

    public Bat bat; // Reference to the Bat script
    public static int strikes = 0;
    public int maxStrikes = 4;
    public static int curr_score = 0;

     private Vector2 touchStartPos;
    private Vector2 touchEndPos;

    public float swipeThreshold = 50f;

    void Start()
    {
        pitch = new New_Pitch();
        pitch.Initialize(GetComponent<Rigidbody>(), forceDirection, forceStrength);

        /// Start the coroutine for the pitch delay
        StartCoroutine(pitch.ContinuousPitching(pitchDelay));
    }

     void Update()
    {

        // if (Input.GetMouseButtonDown(0))
        // {
        //     if (bat != null)
        //     {
        //         bat.BatBall();
        //         if (!bat.forceAdded) {
        //             IncrementStrikes();
        //         }
        //         else if (bat.forceAdded){
        //             curr_score += 2;
        //         }
        //     }
        //     else
        //     {
        //         UnityEngine.Debug.LogError("Bat reference not set in InputManager!");
        //     }
        // }


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touchEndPos = touch.position;

                // Calculate swipe distance
                float swipeDistance = Vector2.Distance(touchStartPos, touchEndPos);

                // Check if the swipe distance is significant
                if (swipeDistance > swipeThreshold)
                {
                    // Swipe detected, handle it
                    // bat.BatBall(touchEndPos - touchStartPos, swipeDistance);
                    if (!bat.forceAdded) {
                        IncrementStrikes();
                    }
                    else if (bat.forceAdded){
                        curr_score += 2;
                    }
                }

            }
        }
    }

    void IncrementStrikes()
    {

        if (!PauseMenu.isPaused) {
            // Increment the strikes count
            strikes++;
        }

        // Check for game over
        if (strikes >= maxStrikes)
        {
            pitch.StopContinuousPitching();
            DBManager.currentScore = curr_score;
            // Not able to update highscore for a user that is already signed in
            // Need to fix
            CallUpdate();
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

    public static void Reset()
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

    public void CallUpdate() {
        if (DBManager.highscore < DBManager.currentScore && DBManager.loggedIn()) {
            StartCoroutine(Upd());
        }
    }

    IEnumerator Upd() {
        // Debug.Log("Updating...");
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("new_score", DBManager.currentScore.ToString());
        string action = "Update";
        form.AddField("action", action);
        string url = "https://cse403-homerunphp.azurewebsites.net/";
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();
        print(www.downloadHandler.text);
        if (www.downloadHandler.text[0] != '0') {
            // Debug.Log("Couldn't update high score: " + www.downloadHandler.text);
        } else {
            // Debug.Log("User high score updated successfully");
            DBManager.highscore = DBManager.currentScore;
        }
    }
}
