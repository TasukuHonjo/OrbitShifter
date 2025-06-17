using UnityEngine;

public class ParticleOnHit : MonoBehaviour
{
    public GameObject hitEffectPrefab; // パーティクルのプレハブ

    float time = 0.5f;
    float defTime = 0f;

    private void Awake()
    {
        defTime = time;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            time = defTime;

            // 衝突点を取得（最初の接触点）
            ContactPoint2D contact = collision.contacts[0];
            Vector2 hitPoint = contact.point;

            // パーティクルを生成
            GameObject effect = Instantiate(hitEffectPrefab, hitPoint, Quaternion.identity);

            // 当たったから中心への方向を計算
            Vector2 direction = Vector2.zero - hitPoint;

            // 角度を算出して回転
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Z軸を回転させて向きを変更（スプライトの右を前提とする）
            effect.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            // 一定時間後に自動破棄（3秒など）
            Destroy(effect, 1f);
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

            time-= Time.deltaTime;

            if (time <= 0)
            {
                time = defTime;

                // 衝突点を取得（最初の接触点）
                ContactPoint2D contact = collision.contacts[0];
                Vector2 hitPoint = contact.point;

                // パーティクルを生成
                GameObject effect = Instantiate(hitEffectPrefab, hitPoint, Quaternion.identity);

                // 当たったから中心への方向を計算
                Vector2 direction = Vector2.zero - hitPoint;

                // 角度を算出して回転
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                // Z軸を回転させて向きを変更（スプライトの右を前提とする）
                effect.transform.rotation = Quaternion.Euler(0f, 0f, angle);

                // 一定時間後に自動破棄（3秒など）
                Destroy(effect, 1f);
            }
            
        }
    }
}
