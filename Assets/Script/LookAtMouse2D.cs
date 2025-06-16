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
        // �}�E�X�̃��[���h���W���擾
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; // Z���W��0�Ɂi2D�Ȃ̂Łj

        // �����̈ʒu����}�E�X�ւ̕������v�Z
        Vector3 direction = mouseWorldPos - transform.position;

        // �p�x���Z�o���ĉ�]
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Z������]�����Č�����ύX�i�X�v���C�g�̉E��O��Ƃ���j
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
