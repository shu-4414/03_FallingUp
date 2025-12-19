using System.ComponentModel;
using UnityEngine;

public class ChangingGravity : MonoBehaviour
{
    // どこからでもアクセスできるようにする
    public static ChangingGravity instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] GravityDatabaseEntity gravityDatabaseEntity = default;

    // 重力の情報を取得する関数
    public GravityColor Spawn (GravityColor.Type type)
    {
        foreach ( GravityColor gravityColor in gravityDatabaseEntity.gravityColors )
        {
            if ( gravityColor.type == type)
            {
                return new GravityColor(gravityColor);
            }
        }
        return null;
    }
}
