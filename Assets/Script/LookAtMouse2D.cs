using UnityEngine;

public class LookAtMouse2D : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody2D rb;

    private void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // マウスのワールド座標を取得
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        // 自分の位置からマウスへの方向を計算
        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        // 角度を算出
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rigidbody2Dで回転を適用（瞬時に向ける場合）
        rb.MoveRotation(angle);
    }
}
