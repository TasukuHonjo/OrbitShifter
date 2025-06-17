using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public GameObject bulletPrefab;     // �e�̃v���n�u
    public float bulletForce = 500f;    // �e�ɉ������
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
        // �}�E�X�̃��[���h���W���擾
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // ���ˈʒu
        Vector3 spawnPos = nozzleTra.position;

        // �}�E�X�����̃x�N�g�����v�Z�E���K��
        Vector2 direction = (mousePos - spawnPos).normalized;

        // �p�x���Z�o�i�X�v���C�g�̉E���O��Ȃ�ȉ���OK�j
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // �e�𐶐�
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.Euler(0f, 0f, angle));

        // Rigidbody2D ��AddForce
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(direction * bulletForce,ForceMode2D.Impulse);
        }
    }
}
