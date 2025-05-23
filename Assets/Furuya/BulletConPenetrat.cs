using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletConPene : MonoBehaviour
{
    /// <summary>�e�̐������ԁi�b�j</summary>
    [SerializeField] float m_lifeTime = 5f;
    /// <summary>�e����ԑ���</summary>
    [SerializeField] float m_speed = 3f;
    [SerializeField] public int m_bulletDamage = 1;


    void Start()
    {

        // �N���b�N�������W�̎擾�i�X�N���[�����W���烏�[���h���W�ɕϊ��j
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // �����̐����iZ�����̏����Ɛ��K���j
        Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

        // �e�ɑ��x��^����
        GetComponent<Rigidbody2D>().velocity = shotForward * m_speed;

        // �������Ԃ��o�߂����玩�����g��j������
        Destroy(this.gameObject, m_lifeTime);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // tag�Ŏ��ʂ���

        if (collision.CompareTag("Enemy") && collision.TryGetComponent(out CharactorBase charactor))
        {
            charactor.DamageBehaviour(m_bulletDamage);
        }
    }

    ///private void OnTriggerEnter2D(Collider2D collision)
    ///{
    // tag�Ŏ��ʂ���

    ///if (collision.CompareTag("Player") && collision.TryGetComponent(out CharactorBase charactor))
    ///{
    ///charactor.DamageBehaviour(m_bulletDamage);
    ///}
    ///}
}