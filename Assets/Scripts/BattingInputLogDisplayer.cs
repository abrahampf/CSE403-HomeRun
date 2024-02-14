using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattingInputLogDisplayer : MonoBehaviour
{
    
    public BattingInputManager battingInputManager; // Reference to the battingInputManager script


    // Start is called before the first frame update
    void Start()
    {
        // Ensure that the battingInputManager reference is assigned
        if (battingInputManager == null)
        {
            UnityEngine.Debug.LogError("battingInputManager reference is not assigned in the inspector.");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TMP_Text tmpText = GetComponent<TMP_Text>();
        // Update the score displayed in the UI Text component
        if (battingInputManager != null && tmpText != null)
        {
            tmpText.text = battingInputManager.swipeVector.ToString() + ", " + battingInputManager.swingDuration;
        }
        else
        {
            UnityEngine.Debug.LogError("TMP Text component is not found on this GameObject.");
        }
    }
    
}
