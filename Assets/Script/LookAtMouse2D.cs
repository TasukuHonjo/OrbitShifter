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
        // �}�E�X�̃��[���h���W���擾
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        // �����̈ʒu����}�E�X�ւ̕������v�Z
        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        // �p�x���Z�o
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rigidbody2D�ŉ�]��K�p�i�u���Ɍ�����ꍇ�j
        rb.MoveRotation(angle);
    }
}
