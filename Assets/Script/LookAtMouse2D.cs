using UnityEngine;

public class LookAtMouse2D : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // マウスのワールド座標を取得
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; // Z座標を0に（2Dなので）

        // 自分の位置からマウスへの方向を計算
        Vector3 direction = mouseWorldPos - transform.position;

        // 角度を算出して回転
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Z軸を回転させて向きを変更（スプライトの右を前提とする）
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
