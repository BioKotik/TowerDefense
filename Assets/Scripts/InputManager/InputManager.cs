using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private World world;
    public void Construct(World world)
    {
        this.world = world;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Input.mousePosition;
            Vector2Int pos = world.Environment.WorldToEnvironmentPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Tower tower = world.TowerManager.FindTowerByPosition(pos);
            tower.ShowButtons();
        }
    }
}
