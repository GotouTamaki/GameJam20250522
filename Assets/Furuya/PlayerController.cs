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
    private const string SHOT_ANIMATION = "Shot";

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
    [SerializeField] Animator m_animator;

    Rigidbody2D m_rb = default;
    SpriteRenderer m_sprite = default;
    /// <summary>m_colors �Ɏg���Y��</summary>
    int m_bulletIndex;
    /// <summary>���������̓��͒l</summary>
    float m_h;
    float m_scaleX;
    /// <summary>�ŏ��ɏo���������W</summary>
    Vector3 m_initialPosition;

    /// <summary>�ђʒe��F����ɂ���</summary>
    //float allColorsValue[]

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
    }

    void Update()
    {
        if (!IsDead)
        {
            // ���͂��󂯎��
            m_h = Input.GetAxisRaw("Horizontal");

            // �e����͂��󂯎��
            //if (Input.GetButtonDown("Jump"))
            //{a
            //    if (_currrentJumpCount > 0)
            //        //Debug.Log("�����ɃW�����v���鏈���������B");
            //        m_rb.AddForce(new Vector2(0, m_jumpPower), ForceMode2D.Impulse);
            //    _currrentJumpCount--;
            //}

            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bullet = null;
                m_animator.SetTrigger(SHOT_ANIMATION);

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

                //for (int i = 0; i<allColorsValue.Length; i++))
                //{
                //allColorValue[i] -= 1;
                //}
            }

            if (Input.GetButtonDown("Fire2"))
            {
                if (m_bulletType == BulletType.Normal)
                {
                    //Debug.Log("�����ɒe�ۂ�؂�ւ��鏈���������B");
                    m_bulletType = BulletType.Penetrat;
                }
                else if (m_bulletType == BulletType.Penetrat)
                {
                    m_bulletType = BulletType.Normal;
                }
            }

            // �ݒ�ɉ����č��E�𔽓]������
            if (m_flipX)
            {
                FlipX(m_h);
            }
        }
        else
        {
            OnDead();
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