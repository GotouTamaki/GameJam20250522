using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    /// <summary>�e����ԑ���</summary>
    [SerializeField] float _speed = 3f;
    /// <summary>�e�̐������ԁi�b�j</summary>
    [SerializeField] float _lifeTime = 3f;

    public int _bulletAttack;

    private Vector3 _moveDirection;

    public void OnInitialize(Vector3 direction, int enemyAttck)
    {
        _moveDirection = direction;
        _bulletAttack = enemyAttck * _bulletAttack;
    }

    // Start is called before the first frame update
    void Start()
    {
        // �E�����ɔ�΂�
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = _moveDirection * _speed;

        // �������Ԃ��o�߂����玩�����g��j������
        Destroy(this.gameObject, _lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Crystal"))
        {
            if (collision.TryGetComponent<CharactorBase>(out var CharactorBase))
            {
                CharactorBase.DamageBehaviour(_bulletAttack);
            }

            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("FriendsBullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
