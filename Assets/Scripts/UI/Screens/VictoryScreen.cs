using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

public class VictoryScreen : MonoBehaviour, IScreen
{
    [SerializeField] private NextLevelButton nextNextLevelButton;

    public NextLevelButton NextLevelButton
    {
        get => nextNextLevelButton;
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