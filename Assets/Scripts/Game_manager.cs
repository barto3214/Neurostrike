using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class Game_manager : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text enemies_left_text;
    [SerializeField] GameObject you_win_text;
    [SerializeField] GameObject menu_container;
    [SerializeField] GameObject options_container;
    public int enemies_to_kill = 0;
    public void adjustEnemiesLeft(int enemies_left)
    {
        enemies_to_kill += enemies_left;
        enemies_left_text.text = "Enemies left: " + enemies_to_kill.ToString();
        if (enemies_to_kill <= 0)
        {
            Player_health playerHealth = FindFirstObjectByType<Player_health>();
            Debug.Log("You win!");
            playerHealth.win(you_win_text);
        }
    }


    public void restartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void quitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Nextlevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Start_game()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }

    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void Options()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Options");
    }
}