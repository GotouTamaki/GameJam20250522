using UnityEngine;

enum BulletType
{
    None,
    Normal,
    Penetrat,
}

/// <summary>
/// ガンマンのキャラクターを操作するコンポーネント
/// </summary>
public class PlayerController : CharactorBase
{
    private const string SHOT_ANIMATION = "Shot";

    /// <summary>左右移動する力</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>ジャンプする力</summary>
    [SerializeField] float m_jumpPower = 15f;
    /// <summary>色の配列</summary>
    ///[SerializeField] Color[] m_colors = default;
    /// <summary>弾丸のプレハブ</summary>
    [SerializeField] GameObject[] m_bulletPrefab = default;
    /// <summary>銃口の位置を設定するオブジェクト</summary>
    [SerializeField] Transform m_muzzle = default;
    /// <summary>入力に応じて左右を反転させるかどうかのフラグ</summary>
    [SerializeField] bool m_flipX = false;
    [SerializeField] Animator m_animator;

    Rigidbody2D m_rb = default;
    SpriteRenderer m_sprite = default;
    /// <summary>m_colors に使う添字</summary>
    int m_bulletIndex;
    /// <summary>水平方向の入力値</summary>
    float m_h;
    float m_scaleX;
    /// <summary>最初に出現した座標</summary>
    Vector3 m_initialPosition;

    /// <summary>貫通弾を色消費にする</summary>
    //float allColorsValue[]

    BulletType m_bulletType = BulletType.Normal;

    [SerializeField] int _jumpCount = 2;
    int _currrentJumpCount;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        // 初期位置を覚えておく
        m_initialPosition = this.transform.position;
        _currrentJumpCount = _jumpCount;
    }

    void Update()
    {
        if (!IsDead)
        {
            // 入力を受け取る
            m_h = Input.GetAxisRaw("Horizontal");

            // 各種入力を受け取る
            //if (Input.GetButtonDown("Jump"))
            //{a
            //    if (_currrentJumpCount > 0)
            //        //Debug.Log("ここにジャンプする処理を書く。");
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
                //Debug.Log("ここに弾を発射する処理を書く。");
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
                    //Debug.Log("ここに弾丸を切り替える処理を書く。");
                    m_bulletType = BulletType.Penetrat;
                }
                else if (m_bulletType == BulletType.Penetrat)
                {
                    m_bulletType = BulletType.Normal;
                }
            }

            // 設定に応じて左右を反転させる
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
        // 力を加えるのは FixedUpdate で行う
        m_rb.AddForce(Vector2.right * m_h * m_movePower, ForceMode2D.Force);
    }

    /// <summary>
    /// 左右を反転させる
    /// </summary>
    /// <param name="horizontal">水平方向の入力値</param>
    void FlipX(float horizontal)
    {
        /*
         * 左を入力されたらキャラクターを左に向ける。
         * 左右を反転させるには、Transform:Scale:X に -1 を掛ける。
         * Sprite Renderer の Flip:X を操作しても反転する。
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
            Debug.Log("着地");
        }
    }
}