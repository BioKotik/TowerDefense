using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public event Action OnClick;

    private void Awake()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnClickHandler);
    }

    private void OnClickHandler()
    {
        OnClick?.Invoke();
    }
}
