using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody rb;

    [Header("マウス感度設定")]
    [SerializeField] private float mouseSensitivity = 2f;

    [Header("カメラ設定")]
    [SerializeField] private Transform playerCamera;
    
    private float xRotation = 0f;
    public bool isGravityMove = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        // 回転による転倒防止
        rb.freezeRotation = true;

        // カーソル設定(ゲーム画面の中央にロック)
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseLook();

        // 重力方向に応じてプレイヤーを回転
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, -Physics.gravity.normalized) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A,D
        float moveZ = Input.GetAxisRaw("Vertical"); // W,S

        // 現在の重力方向を取得（正規化）
        Vector3 gravityDir = Physics.gravity.normalized;

        // 現在の重力方向を下とみなした座標系を作る
        Vector3 playerUp = -gravityDir;
        Vector3 playerForward = Vector3.ProjectOnPlane(transform.forward, playerUp).normalized;
        Vector3 playerRight = Vector3.ProjectOnPlane(transform.right, playerUp).normalized;

        // 入力方向を組み立てる
        Vector3 move = (playerRight * moveX + playerForward * moveZ).normalized;

        // 新しい速度（重力成分は消さない）
        Vector3 newVelocity = move * moveSpeed + Vector3.Project(rb.linearVelocity, gravityDir);
        rb.linearVelocity = newVelocity;
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // 左右回転（プレイヤー本体）
        transform.Rotate(Vector3.up * mouseX);

        // 上下回転（カメラのみ）
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); // 視点制限
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        
    }

    private void OnCollisionStay(Collision collision)
    {
        isGravityMove = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGravityMove = false;
    }

}
