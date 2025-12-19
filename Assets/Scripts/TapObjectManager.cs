using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Interactions;

public class TapObjectManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        // クリックまたはタップされた瞬間を検知する
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // カメラからタップ位置へのビーーーム
            RaycastHit hit;

            // Rayがオブジェクトに当たったかを判定する
            if (Physics.Raycast(ray, out hit))
            {
                // 当たったオブジェクトがTapObjectを持っているかを確認
                TapObject tap = hit.collider.GetComponent<TapObject>();
                if (tap != null)
                {
                    tap.InvokeTap();
                }
                else
                {
                    return;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // カメラからタップ位置へのビーーーム
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                HoldObject hold = hit.collider.GetComponent<HoldObject>();
                if (hold != null)
                {
                    hold.InvokeHold();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
