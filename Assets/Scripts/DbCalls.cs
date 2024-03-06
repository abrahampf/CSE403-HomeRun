using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DbCalls : MonoBehaviour
{
    public InputField username;
    public InputField passwordField;
    public Button SignInButton;
    public Button RegisterButton;
    public string action;

    public Text backendResponse;
    public static Dictionary<string, int> users = new Dictionary<string, int>();

    // Start is called before the first frame update
    public void CallSignIn() {
        StartCoroutine(LogIn());
    }

    public void CallRegister() {
        StartCoroutine(Register());
    }

    public void CallUpdate() {
        if (DBManager.highscore < DBManager.currentScore && DBManager.loggedIn()) {
            StartCoroutine(Upd());
        }
    }

    public void CallLeader() {
        StartCoroutine(Leader());
    }

    IEnumerator LogIn() {
        WWWForm form = new WWWForm();
        Debug.Log("Trying to Log in");
        action = "LogIn";
        form.AddField("username", username.text);
        form.AddField("password", passwordField.text);
        form.AddField("action", action);
        string url = "https://cse403-homerunphp.azurewebsites.net";
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        backendResponse.text = "Logging in...";
        yield return www.SendWebRequest();

        if (www.downloadHandler.text[0] != '0') {
            Debug.Log("User log in failed. Error " + www.downloadHandler.text);
            string errorString = www.downloadHandler.text;
            int colonIndex = errorString.IndexOf(':');
            string errorMessage = errorString[(colonIndex + 2)..];
            backendResponse.text = errorMessage;
            float delayInSeconds = 2.5f;
            Invoke(nameof(ReloadLoginScene), delayInSeconds);
        } else {
            Debug.Log("User logged in successfully");
            backendResponse.text = "Logged in as: " + username.text;
            DBManager.username = username.text;
            int db_highscore = int.Parse(www.downloadHandler.text.Split('\t')[1]);
            if (DBManager.currentScore > db_highscore) {
                CallUpdate();
            } else {
                DBManager.highscore = db_highscore;
            }


            // Timers
            yield return new WaitForSeconds(3f);
            float delayInSeconds = 3f;
            backendResponse.text = "Loading...";
            CallLeader();
            Invoke(nameof(LeaderboardScene), delayInSeconds);
        }
    }

    IEnumerator Register() {
        WWWForm form = new WWWForm();
        Debug.Log("Trying to register");
        action = "Register";
        form.AddField("username", username.text);
        form.AddField("password", passwordField.text);
        form.AddField("action", action);
        form.AddField("highscore", DBManager.currentScore.ToString());
        string url = "https://cse403-homerunphp.azurewebsites.net";
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        backendResponse.text = "Register...";
        yield return www.SendWebRequest();


        if (www.downloadHandler.text[0] != '0') {
            Debug.Log("User registrations failed. Error " + www.downloadHandler.text);
            string errorString = www.downloadHandler.text;
            int colonIndex = errorString.IndexOf(':');
            string errorMessage = errorString[(colonIndex + 2)..];
            backendResponse.text = errorMessage;
            float delayInSeconds = 3f;
            Invoke(nameof(ReloadLoginScene), delayInSeconds);
        } else {
            Debug.Log("Registered successfully");
            backendResponse.text = "Created Account as: " + username.text;
            DBManager.highscore = DBManager.currentScore;
            DBManager.username = username.text;


            // Timers
            yield return new WaitForSeconds(3f);
            float delayInSeconds = 3f;
            backendResponse.text = "Loading...";
            CallLeader();
            Invoke(nameof(LeaderboardScene), delayInSeconds);
        }
    }

    // Update is called once per frame
    IEnumerator Upd() {
        Debug.Log("Updating...");
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
            Debug.Log("Couldn't update high score: " + www.downloadHandler.text);
        } else {
            Debug.Log("User high score updated successfully");
            DBManager.highscore = DBManager.currentScore;
        }
    }

    // Update is called once per frame
    IEnumerator Leader()
    {
        Debug.Log("Getting leaders...");
        WWWForm form = new WWWForm();
        string action = "Leaderboard";
        form.AddField("action", action);
        string url = "https://cse403-homerunphp.azurewebsites.net/";
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();
        if (www.downloadHandler.text[0] != '0') {
            Debug.Log("User log in failed. Error " + www.downloadHandler.text);
        } else {
            Debug.Log(www.downloadHandler.text);
            string backendString = www.downloadHandler.text;
            string user_and_scores = backendString[2..];
            Debug.Log(user_and_scores);
            string[] usersNumberPairs = user_and_scores.Split('\t');
            Debug.Log(usersNumberPairs.ToString());
            foreach(var pair in usersNumberPairs) {
                string[] seperate = pair.Split(':');
                if (seperate.Length == 2) {
                    string user = seperate[0];
                    if (int.TryParse(seperate[1], out int user_score))
                    {
                        users.Add(user, user_score);
                    }
                }
            }
        }
    }

    public void GoBack() {
        SceneManager.LoadScene("BeginScene");
    }

    public static void Clear_Dictionary() {
        users.Clear();
    }

    void LeaderboardScene() {
        SceneManager.LoadScene("New_Leader");
    }

    void ReloadLoginScene()
    {
        SceneManager.LoadScene("LoginPage4");
    }

    public void properInputsRegister() {
        RegisterButton.interactable = username.text.Length >= 4 && passwordField.text.Length >= 4;
    }
}
