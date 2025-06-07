using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    /// <summary>’e‚ª”ò‚Ô‘¬‚³</summary>
    [SerializeField] float _speed = 3f;
    /// <summary>’e‚Ì¶‘¶ŠúŠÔi•bj</summary>
    [SerializeField] float _lifeTime = 3f;

    public int _bulletAttack;
    [SerializeField] int _hp = 50;

    private Vector3 _moveDirection;

    public void OnInitialize(Vector3 direction, int enemyAttck)
    {
        _moveDirection = direction;
        _bulletAttack = enemyAttck * _bulletAttack;
    }

    // Start is called before the first frame update
    void Start()
    {
        // ‰E•ûŒü‚É”ò‚Î‚·
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = _moveDirection * _speed;

        // ¶‘¶ŠúŠÔ‚ªŒo‰ß‚µ‚½‚ç©•ª©g‚ğ”jŠü‚·‚é
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
		else if (collision.CompareTag("Bullet")) //(FriendBullet‚©‚çBullet‚É•ÏX)
        {
            /*if (collision.TryGetComponent<BulletCon>(out var bullet))
            _hp -= collision.gameObject.GetComponent<BulletCon>().m_bulletDamage;
            {
                _hp -= bullet.m_bulletDamage;
            }

            if(_hp < 0)
            {
				Destroy(this.gameObject);
			}*/

            // ’Êí’e
            if (collision.TryGetComponent<BulletCon>(out var normalBullet))
            {
                _hp -= normalBullet.m_bulletDamage;

                if (_hp < 0)
                {
                    Destroy(this.gameObject);
                }
            }
            // ŠÑ’Ê’e
            else if (collision.TryGetComponent<BulletConPene>(out var piercingBullet))
            {
                _hp -= piercingBullet.m_bulletDamage;

                if (_hp < 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
	}
}
