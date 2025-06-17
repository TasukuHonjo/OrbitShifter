using UnityEngine;

public class HitBulletEfect : MonoBehaviour
{
    public GameObject hitEffectPrefab; // �p�[�e�B�N���̃v���n�u

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �Փ˓_���擾�i�ŏ��̐ڐG�_�j
        Vector2 hitPoint = collision.ClosestPoint(transform.position);

        // �p�[�e�B�N���𐶐�
        GameObject effect = Instantiate(hitEffectPrefab, hitPoint, Quaternion.identity);

        // �����������璆�S�ւ̕������v�Z
        Vector2 direction = Vector2.zero - hitPoint;

        // �p�x���Z�o���ĉ�]
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Z������]�����Č�����ύX�i�X�v���C�g�̉E��O��Ƃ���j
        effect.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // ��莞�Ԍ�Ɏ����j���i3�b�Ȃǁj
        Destroy(effect, 1f);
    }
}
