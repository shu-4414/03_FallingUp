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
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A,D
        float moveZ = Input.GetAxisRaw("Vertical"); // W,S

        Vector3 move = (transform.right * moveX + transform.forward * moveZ).normalized;
        rb.linearVelocity = move * moveSpeed;
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
}
