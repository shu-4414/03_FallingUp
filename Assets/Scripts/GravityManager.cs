using System;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public static GravityManager Instance;

    public GravityColor.Type CurrentColor { get; private set; } = GravityColor.Type.None;

    public GravityDatabaseEntity database;

    private void Start()
    {
        Instance = this;
        SetGravity(GravityColor.Type.Blue);
    }

    public void SetGravity (GravityColor.Type newColor)
    {
        var data = database.gravityColors.Find(d => d.type == newColor);
        if (data == null)
        {
            Debug.LogWarning($"Gravity data({newColor}) not found.");
            return;
        }

        // 重力の更新
        Physics.gravity = data.gravity;
        
        // 色の更新
        CurrentColor = newColor;
        Debug.Log($"CurrentColor = {newColor}, Right?");

        // 床の色の更新
        UpdateFloors();
    }

    private void UpdateFloors()
    {
        var floors = FindObjectsByType<ColorFloor>(FindObjectsSortMode.None);
        foreach ( var floor in floors)
        {
            floor.RefreshColor(CurrentColor);
        }

        var walls = FindObjectsByType<GravityMove>(FindObjectsSortMode.None);
        foreach ( var wall in walls)
        {
            wall.RefreshWallColor(CurrentColor);
        }

    }


}
