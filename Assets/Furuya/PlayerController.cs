using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

enum BulletType
{
    None,
    Normal,
    Penetrat,
}

/// <summary>
/// �K���}���̃L�����N�^�[�𑀍삷��R���|�[�l���g
/// </summary>
public class PlayerController : CharactorBase
{
    /// <summary>���E�ړ������</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>�W�����v�����</summary>
    [SerializeField] float m_jumpPower = 15f;
    /// <summary>�F�̔z��</summary>
    ///[SerializeField] Color[] m_colors = default;
    /// <summary>�e�ۂ̃v���n�u</summary>
    [SerializeField] GameObject[] m_bulletPrefab = default;
    /// <summary>�e���̈ʒu��ݒ肷��I�u�W�F�N�g</summary>
    [SerializeField] Transform m_muzzle = default;
    /// <summary>���͂ɉ����č��E�𔽓]�����邩�ǂ����̃t���O</summary>
    [SerializeField] bool m_flipX = false;

    [SerializeField] float m_bulletChangeDuration = 5f;

    Rigidbody2D m_rb = default;
    SpriteRenderer m_sprite = default;
    /// <summary>m_colors �Ɏg���Y��</summary>
    int m_bulletIndex;
    /// <summary>���������̓��͒l</summary>
    float m_h;
    float m_scaleX;
    /// <summary>�ŏ��ɏo���������W</summary>
    Vector3 m_initialPosition;

    float _bulletChangeTime = 0;
    ///<summary>���Ԍv���̂��߂̕ϐ�
    private float time;





    BulletType m_bulletType = BulletType.Normal;

    [SerializeField] int _jumpCount = 2;
    int _currrentJumpCount;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        // �����ʒu���o���Ă���
        m_initialPosition = this.transform.position;
        _currrentJumpCount = _jumpCount;
        time = 1.0f;�@//�ŏ���1���OK
    }

    void Update()
    {
        // ���͂��󂯎��
        m_h = Input.GetAxisRaw("Horizontal");

        // �e����͂��󂯎��
        if (Input.GetButtonDown("Jump"))
        {
            if (_currrentJumpCount > 0)
                //Debug.Log("�����ɃW�����v���鏈���������B");
                m_rb.AddForce(new Vector2(0, m_jumpPower), ForceMode2D.Impulse);
            _currrentJumpCount--;
        }

        
        //�A�ˏo���Ȃ��悤�ɂ��ďe������
        time += Time.deltaTime;�@//���Ԃ𑝂₷
        if (time >= 1.0f) //1�b�ȏ�o�Ă�OK
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bullet = null;

                switch (m_bulletType)
                {
                    case BulletType.Normal:
                        bullet = Instantiate(m_bulletPrefab[0]);
                        break;
                    case BulletType.Penetrat:
                        bullet = Instantiate(m_bulletPrefab[1]);
                        break;
                    default:
                        break;
                }
                //Debug.Log("�����ɒe�𔭎˂��鏈���������B");
                //bullet.transform.position = transform.position;
                bullet.transform.position = m_muzzle.position;
            }
        time = 0.0f; //���Ԃ�������
        }


        if (Input.GetButtonDown("Fire2"))
        {
            //Debug.Log("�����ɒe�ۂ�؂�ւ��鏈���������B");
            m_bulletType = BulletType.Penetrat;
            _bulletChangeTime = Time.time;
        }

        if(m_bulletType != BulletType.Normal && Time.time - _bulletChangeTime >= m_bulletChangeDuration)
        {
            m_bulletType = BulletType.Normal;
            Debug.Log(Time.time - _bulletChangeTime);
        }

       


        // �ݒ�ɉ����č��E�𔽓]������
        if (m_flipX)
        {
            FlipX(m_h);
        }
    }


    private void FixedUpdate()
    {
        // �͂�������̂� FixedUpdate �ōs��
        m_rb.AddForce(Vector2.right * m_h * m_movePower, ForceMode2D.Force);
    }

    /// <summary>
    /// ���E�𔽓]������
    /// </summary>
    /// <param name="horizontal">���������̓��͒l</param>
    void FlipX(float horizontal)
    {
        /*
         * ������͂��ꂽ��L�����N�^�[�����Ɍ�����B
         * ���E�𔽓]������ɂ́ATransform:Scale:X �� -1 ���|����B
         * Sprite Renderer �� Flip:X �𑀍삵�Ă����]����B
         * */
        m_scaleX = this.transform.localScale.x;

        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _currrentJumpCount = _jumpCount;
            Debug.Log("���n");
        }
    }
}