using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignIn : MonoBehaviour
{
    public InputField username;
    public InputField passwordField;
    public Button SignInButton;
    public Button CreateNewButton;
    public string action;

    public Text backendResponse;
    // Start is called before the first frame update
    void Start()
    {
        SignInButton.onClick.AddListener(CallSignIn);
        CreateNewButton.onClick.AddListener(CallRegister);
    }

    public void CallSignIn() {
        StartCoroutine(LogIn());
    }

    public void CallRegister() {
        StartCoroutine(Register());
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
        yield return www.SendWebRequest();

        if (www.downloadHandler.text != "0") {
            Debug.Log("User log in failed. Error " + www.downloadHandler.text);
            backendResponse.text = www.downloadHandler.text;
            float delayInSeconds = 6f;
            Invoke(nameof(ReloadLoginScene), delayInSeconds);
        } else {
            Debug.Log("User logged in successfully");
            backendResponse.text = "Logged in as: " + username.text;
            yield return new WaitForSeconds(3f);
            float delayInSeconds = 3f;
            backendResponse.text = "Loading game...";
            Invoke(nameof(GameScene), delayInSeconds);
        }
    }

    IEnumerator Register() {
        WWWForm form = new WWWForm();
        Debug.Log("Trying to register");
        action = "Register";
        form.AddField("username", username.text);
        form.AddField("password", passwordField.text);
        form.AddField("action", action);
        string url = "https://cse403-homerunphp.azurewebsites.net";
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();


        if (www.downloadHandler.text != "0") {
            Debug.Log("User registrations failed. Error " + www.downloadHandler.text);
            backendResponse.text = www.downloadHandler.text;
            float delayInSeconds = 6f;
            Invoke(nameof(ReloadLoginScene), delayInSeconds);
        } else {
            Debug.Log("Registered successfully");
            backendResponse.text = "Created Account as: " + username.text;
            yield return new WaitForSeconds(3f);
            float delayInSeconds = 3f;
            backendResponse.text = "Loading game...";
            Invoke(nameof(GameScene), delayInSeconds);
        }
    }

    void GameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void ReloadLoginScene()
    {
        SceneManager.LoadScene(0);
    }

}
