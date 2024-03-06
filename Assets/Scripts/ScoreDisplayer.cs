using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    // public static ScoreTracker scoreTracker; // Reference to the ScoreTracker script
    public Text scoreText; // Reference to the TextMeshPro component

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Update the score displayed in the UI Text component
        if (scoreText != null)
        {
            scoreText.text = ScoreTracker.score.ToString("F2");
        }
        else
        {
            UnityEngine.Debug.LogError("TextMeshPro component not found for displaying score!");
        }
    }
}
