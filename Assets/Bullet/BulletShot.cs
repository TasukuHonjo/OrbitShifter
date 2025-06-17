using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public GameObject bulletPrefab;     // 弾のプレハブ
    public float bulletForce = 500f;    // 弾に加える力
    [SerializeField] private Transform nozzleTra;

    private Camera mainCamera;

    [SerializeField] private float coolTime = 1;
    private float time = 0;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {


        if (Input.GetKey(KeyCode.Space))
        {
            time += Time.deltaTime;
            if (coolTime < time)
            {
                time = 0;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        // マウスのワールド座標を取得
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // 発射位置
        Vector3 spawnPos = nozzleTra.position;

        // マウス方向のベクトルを計算・正規化
        Vector2 direction = (mousePos - spawnPos).normalized;

        // 角度を算出（スプライトの右が前提なら以下でOK）
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 弾を生成
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.Euler(0f, 0f, angle));

        // Rigidbody2D にAddForce
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(direction * bulletForce,ForceMode2D.Impulse);
        }
    }
}
