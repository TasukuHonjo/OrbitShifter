using UnityEngine;

public class ParticleOnHit : MonoBehaviour
{
    public GameObject hitEffectPrefab; // �p�[�e�B�N���̃v���n�u

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

            // �Փ˓_���擾�i�ŏ��̐ڐG�_�j
            ContactPoint2D contact = collision.contacts[0];
            Vector2 hitPoint = contact.point;

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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

            time-= Time.deltaTime;

            if (time <= 0)
            {
                time = defTime;

                // �Փ˓_���擾�i�ŏ��̐ڐG�_�j
                ContactPoint2D contact = collision.contacts[0];
                Vector2 hitPoint = contact.point;

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
    }
}
