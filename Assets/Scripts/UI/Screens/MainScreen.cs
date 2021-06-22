using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : MonoBehaviour, IScreen
{
    [SerializeField] private StartButton startButton;
    [SerializeField] private SettingsButton settingsButton;

    public StartButton StartButton
    {
        get => startButton;
    }

    public SettingsButton SettingsButton
    {
        get => settingsButton;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
