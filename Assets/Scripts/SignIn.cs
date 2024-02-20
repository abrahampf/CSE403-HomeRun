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
    // Start is called before the first frame update
    void Start()
    {
        SignInButton.onClick.AddListener(CallSignIn);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CallSignIn() {
        StartCoroutine(LogIn());
    }

    IEnumerator LogIn() {
        WWWForm form = new WWWForm();
        Debug.Log("Before");
        form.AddField("username", username.text);
        form.AddField("password", passwordField.text);
        // string url = "http://localhost/sqlconnect/signin.php";
        string url = "https://cse403-homerunphp.azurewebsites.net/";
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        // WWW www = new WWW("http://localhost/sqlconnect/sign/in.php", form);
        yield return www.SendWebRequest();


        // For testing
        // gameScene();
        // Debug.Log("User logged in successfully username: " + username.text + "password: " + passwordField.text);


        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log("User log in failed");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        } else {
            Debug.Log("User logged in successfully");
            gameScene();
        }
    }

    void gameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
