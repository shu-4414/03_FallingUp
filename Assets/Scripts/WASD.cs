// こちらのスクリプトはボツになりました。PlayerControllerで移動と視点操作を一本化しました。

using UnityEngine;

public class WASD : MonoBehaviour
{
    Rigidbody rb;
    float speed = 5.0f;
    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Wキー移動
        if (Input.GetKey(KeyCode.W))
    {
            rb.angularVelocity = transform.forward * speed;
        }
        // Sキー移動
        if (Input.GetKey(KeyCode.S))
        {
            rb.angularVelocity = - transform.forward * speed;
        }
        // Dキー移動
        if (Input.GetKey(KeyCode.D))
        {
            rb.angularVelocity = transform.right * speed;
        }
        // Aキー移動
        if (Input.GetKey(KeyCode.A))
        {
            rb.angularVelocity = - transform.right * speed;
    }
}
}

