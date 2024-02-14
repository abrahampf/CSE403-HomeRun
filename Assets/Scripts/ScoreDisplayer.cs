using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplayer : MonoBehaviour
{
    public ScoreTracker scoreTracker; // Reference to the ScoreTracker script

    // Start is called before the first frame update
    void Start()
    {
        // Ensure that the ScoreTracker reference is assigned
        if (scoreTracker == null)
        {
            UnityEngine.Debug.LogError("ScoreTracker reference is not assigned in the inspector.");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TMP_Text tmpText = GetComponent<TMP_Text>();
        // Update the score displayed in the UI Text component
        if (scoreTracker != null && tmpText != null)
        {
            tmpText.text = "Score: " + scoreTracker.score.ToString("F2");
        }
        else
        {
            UnityEngine.Debug.LogError("TMP Text component is not found on this GameObject.");
        }
    }
}
