using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver1 : MonoBehaviour
{
    public Button PlayAgainButton;
    public Button LeaderboardButton;

    // Update is called once per frame
    public void PlayAgain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LeaderBoard()
    {
        if (DBManager.loggedIn()) {
            SceneManager.LoadScene("New_leader");
        } else {
            SceneManager.LoadScene("LoginPage4");
        }
    }
}
