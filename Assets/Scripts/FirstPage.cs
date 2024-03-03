using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstPage : MonoBehaviour
{
    public Button StartGameButton;
    public Button SignInButton;

    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void CallSignIn()
    {
        SceneManager.LoadScene("LoginPage4");
    }
}
