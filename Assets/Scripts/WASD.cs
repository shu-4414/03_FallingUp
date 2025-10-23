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

// C#で書いたコメント（日本語）は文字化けするっぽいから、こっちで書き直していくのがいいのかも。ほかにやり方あればいいな
// ちなみにこっちで書いた日本語は正しく読まれないとおもう。