using System.Collections.Generic;
using UnityEngine;

public class Game_settings : MonoBehaviour
{
    public static Game_settings Instance;
    Dictionary<string, (int, int, bool)> resolutions = new Dictionary<string, (int, int, bool)> {
        {"1920", (1920, 1080, true)},
        {"1280", (1280, 720, true)},
        {"800", (800, 600, true)},
    };

    string[] resolutionKeys = new string[] { "1920", "1280", "800" };
    string[] fullscreen_Keys = new string[] { "ExclusiveFullScreen", "MaximizedWindow", "Windowed" };

    [SerializeField] TMPro.TMP_Dropdown resolutionDropdown;
    [SerializeField] TMPro.TMP_Dropdown fullscreen;


    void Start()
    {
        // Dodajemy listener do Dropdown
        resolutionDropdown.onValueChanged.AddListener(OnResolutionDropdownChanged);
        fullscreen.onValueChanged.AddListener(OnFullscreenDropdownChanged);
    }
    private void OnResolutionDropdownChanged(int index)
    {
        Screen.SetResolution(resolutions[resolutionKeys[index]].Item1, resolutions[resolutionKeys[index]].Item2, resolutions[resolutionKeys[index]].Item3);
        Debug.Log("Resolution changed to: " + resolutions[resolutionKeys[index]].Item1 + "x" + resolutions[resolutionKeys[index]].Item2 + " Fullscreen: " + resolutions[resolutionKeys[index]].Item3);
    }
    private void OnFullscreenDropdownChanged(int index)
    {
        Screen.fullScreenMode = fullscreen_Keys[index] switch
        {
            "ExclusiveFullScreen" => FullScreenMode.ExclusiveFullScreen,
            "MaximizedWindow" => FullScreenMode.MaximizedWindow,
            "Windowed" => FullScreenMode.Windowed,
            _ => Screen.fullScreenMode
        };
        Debug.Log("Fullscreen mode changed to: " + fullscreen_Keys[index]);
    }
}
