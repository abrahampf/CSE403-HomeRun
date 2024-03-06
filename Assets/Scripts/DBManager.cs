using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DBManager {

    public static string username = null;
    public static int highscore = 0;
    public static int currentScore = 0;
    public static bool loggedIn() {
        return username != null;
    }

    public static void logOut() {
        username = null;
        highscore = 0;
        currentScore = 0;
    }

    public static void updateScore() {
        currentScore += (int) ScoreTracker.score;
    }
}