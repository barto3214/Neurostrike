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

    Dictionary<string, (int, int, bool)> resolutions = new Dictionary<string, (int, int, bool)> {
        {"1920", (1920, 1080, true)},
        {"1280", (1280, 720, true)},
        {"800", (800, 600, false)}
    };

    string[] resolutionKeys = new string[] { "1920", "1280", "800" };

    [SerializeField] TMPro.TMP_Dropdown resolutionDropdown;


    void Start()
    {
        // Dodajemy listener do Dropdown
        resolutionDropdown.onValueChanged.AddListener(OnResolutionDropdownChanged);
    }
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
        //There will be inferrence to next level
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

    public void OnResolutionDropdownChanged(int index)
    {
        Screen.SetResolution(resolutions[resolutionKeys[index]].Item1, resolutions[resolutionKeys[index]].Item2, resolutions[resolutionKeys[index]].Item3);
        Debug.Log("Resolution changed to: " + resolutions[resolutionKeys[index]].Item1 + "x" + resolutions[resolutionKeys[index]].Item2 + " Fullscreen: " + resolutions[resolutionKeys[index]].Item3);
    }
}