using System;
using UnityEngine;

[Serializable]

public class GravityColor // 重力の方向をそれぞれ「色」で管理する。
{
    // 重力の向きの種類
    public enum Type
    {
        None,
        Blue,
        Red,
        Yellow,
        Green,
        Orange,
        Purple,
    }
    
    public Type type;

    // 重力の方向
    public Vector3 gravity;

    public Color color;

    // コンストラクタ
    public GravityColor (GravityColor gravityColor)
    {
        this.type = gravityColor.type;
        this.gravity = gravityColor.gravity;
        this.color = gravityColor.color;
    }
}
