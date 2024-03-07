using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject InstruObj;

    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        InstruObj.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }
    }

    public void PauseGame()
    {

        if (PitchManger.curr_score > 0) {
            PitchManger.curr_score--;
        }
        isPaused = true;
        pauseMenu.SetActive(true);
        InstruObj.SetActive(false);
        Time.timeScale = 0f;
    }


    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        InstruObj.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }


    public void GoToMainMenu ()
    {
        PitchManger.Reset();
        Time.timeScale = 1f;
        if (DBManager.loggedIn()) {
            SceneManager.LoadScene("New_leader");
        } else {
            SceneManager.LoadScene("BeginScene");
        }
        isPaused = false;
    }

    public void Instructions()
    {
        pauseMenu.SetActive(false);
        InstruObj.SetActive(true);
        Time.timeScale = 0f;
        // SceneManager.LoadScene("InstructionPage");
    }

    public void MainScene()
    {
        InstruObj.SetActive(false);
        Time.timeScale = 1f;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        // Time.timeScale = 1f;
        // SceneManager.LoadScene("MainScene");
    }

}
