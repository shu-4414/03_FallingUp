using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject ClearUI;
    private bool isGoal = false;

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーがゴールに触れた
        if (other.CompareTag("Player") && !isGoal)
        {
            isGoal = true;
            ShowClearUI();

            // カーソルを解放
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // PlayerControllerの無効化
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.enabled = false;
            }

            // Rigidbodyの停止
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.angularVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }
        }
    }

    void ShowClearUI()
    {
        if (ClearUI != null)
        {
            Debug.Log("Clear!");
            ClearUI.SetActive(true);
            Time.timeScale = 1f;
        }
        else
        {
            Debug.Log("Clear! But ClearUI is null");
        }
    }
}
