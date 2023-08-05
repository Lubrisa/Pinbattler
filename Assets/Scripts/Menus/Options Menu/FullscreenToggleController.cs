using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggleController : MonoBehaviour
{
    private void Start()
    {
        Toggle fullscreenToggle = GetComponent<Toggle>();

        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void SetNewFullscreenValue(bool value)
    {
        Screen.fullScreen = value;
        PlayerPrefs.SetInt("Fullscreen", value ? 0 : 1);
    }
}