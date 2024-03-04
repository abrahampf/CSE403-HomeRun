using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display_Highscore : MonoBehaviour
{
    public Text display_highscore;
    // Start is called before the first frame update
    void Start()
    {
        if (display_highscore != null) {
            display_highscore.text = $"{DBManager.highscore}";
        } else {
            UnityEngine.Debug.LogError("Highscore text is null");
        }
    }
}
