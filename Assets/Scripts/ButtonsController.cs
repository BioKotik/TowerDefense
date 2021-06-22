using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    public Tower tower;
    [SerializeField] private Button upgradeButton, destroyButton, closeButton;

    private void Start()
    {
        upgradeButton.onClick.AddListener(() => tower.Upgrade());
        destroyButton.onClick.AddListener(() => Destroy(tower.gameObject));
        closeButton.onClick.AddListener(() => this.gameObject.SetActive(false));
    }
}
