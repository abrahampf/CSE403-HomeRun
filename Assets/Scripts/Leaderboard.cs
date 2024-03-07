using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text rank;
    public Text user;
    public Text score;

    public Button StartGameButton;
    public Button LogoutButton;
    // Start is called before the first frame update

    void Start() {
        var topUsers = DbCalls.users.OrderByDescending(entry => entry.Value).Take(5);
        // Null check for leaderboardText
        if (rank != null) {
            int i = 1;
            foreach (var entry in topUsers) {
                rank.text += $"{i}\n";
                if (string.Equals(entry.Key,DBManager.username)) {
                    user.text += $"{entry.Key} (You)\n";
                } else {
                    user.text += $"{entry.Key}\n";
                }
                score.text += $"{entry.Value}\n";
                i++;
            }
        } else {
            Debug.LogError("leaderboardText is null. Make sure to assign it in the Unity Editor.");
        }
    }

    public void GameScene()
    {
        // Debug.Log("Game scene here");
        SceneManager.LoadScene("MainScene");
    }

    public void BeginScene()
    {
        // Debug.Log("Begin scene here");
        DBManager.logOut();
        DbCalls.Clear_Dictionary();
        SceneManager.LoadScene("BeginScene");
    }
}
