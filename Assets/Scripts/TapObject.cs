using UnityEngine;

public class TapObject : MonoBehaviour
{
    
    // Managerから呼ばれる
    public void InvokeTap()
    {
        OnTap();
    }

    // 派生クラスでオーバーライドして動作を定義する
    protected virtual void OnTap()
    {

    }
}
