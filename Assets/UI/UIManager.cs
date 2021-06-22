using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager
{
    private ScreenController screenController;
    public ScreenController ScreenController
    {
        get => screenController;
        private set => screenController = value;
    }

    public UIManager Instantiate(UIConfig config)
    {
        var UI = GameObject.Instantiate(config.PrefabUI);
        UI.name = "UI";
        this.ScreenController = UI.GetComponent<ScreenController>();
        InitEventSystem();
        ScreenController.HideAll();
        ScreenController.MainScreen.Show();
        return this;
    }

    private static void InitEventSystem()
    {
        if (GameObject.FindObjectOfType<EventSystem>() == null)
        {
            var eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }
    }
}
