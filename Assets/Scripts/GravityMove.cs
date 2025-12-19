using UnityEngine;
using UnityEngine.EventSystems;

public class GravityMove : TapObject
{
    public GravityColor.Type gravityType;

    [SerializeField] GravityColor defaultColor;

    private Renderer rend;

    public PlayerController playerController;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        playerController = FindAnyObjectByType<PlayerController>();
    }

    protected override void OnTap()
    {
        if (playerController.isGravityMove == false)
        {
            return;
        }
        else
        {
            GravityManager.Instance.SetGravity(gravityType);
        }
        
    }

    public void RefreshWallColor(GravityColor.Type current)
    {
        var db = GravityManager.Instance.database;
        var data = db.gravityColors.Find(d => d.type == current);

        if (current == gravityType)
        {
            // 今の重力方向と同じならカラーを反映
            rend.material.color = data.color;
        }
        else
        {
            // 重力がかからなくなったらデフォルト色へ
            rend.material.color = defaultColor.color;
        }
    }
}
