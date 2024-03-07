using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display_Highscore : MonoBehaviour
{
    public Text display_highscore;
    public Text current_strikes;
    public Text scoreText; // Reference to the TextMeshPro component
    // Start is called before the first frame update
    void Start()
    {
        if (display_highscore != null) {
            display_highscore.text = $"{DBManager.highscore}";
            current_strikes.text = $"Strikes: {PitchManager.Get_strikes()}";
            scoreText.text = $"{PitchManager.Get_strikes()}";
        } else {
            UnityEngine.Debug.LogError("Highscore text is null");
        }
    }

    void Update() {
         current_strikes.text = $"Strikes: {PitchManager.Get_strikes()}";
         scoreText.text = $"{PitchManager.Get_Score()}";
    }
}
