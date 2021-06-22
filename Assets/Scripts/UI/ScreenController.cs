using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    [SerializeField] private MainScreen mainScreen;
    [SerializeField] private DefeatScreen defeatScreen;
    [SerializeField] private VictoryScreen victoryScreen;

    public MainScreen MainScreen
    {
        get => mainScreen;
    }

    public DefeatScreen DefeatScreen
    {
        get => defeatScreen;
    }

    public VictoryScreen VictoryScreen
    {
        get => victoryScreen;
    }

    public void HideAll()
    {
        var screens = GetComponentsInChildren<IScreen>();
        foreach (var screen in screens)
        {
            screen.Hide();
        }
    }
}
