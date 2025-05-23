using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletConPene : MonoBehaviour
{
    /// <summary>弾の生存期間（秒）</summary>
    [SerializeField] float m_lifeTime = 5f;
    /// <summary>弾が飛ぶ速さ</summary>
    [SerializeField] float m_speed = 3f;
    [SerializeField] public int m_bulletDamage = 1;


    void Start()
    {

        // クリックした座標の取得（スクリーン座標からワールド座標に変換）
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 向きの生成（Z成分の除去と正規化）
        Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

        // 弾に速度を与える
        GetComponent<Rigidbody2D>().velocity = shotForward * m_speed;

        // 生存期間が経過したら自分自身を破棄する
        Destroy(this.gameObject, m_lifeTime);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // tagで識別する

        if (collision.CompareTag("Enemy") && collision.TryGetComponent(out CharactorBase charactor))
        {
            charactor.DamageBehaviour(m_bulletDamage);
        }
    }

    ///private void OnTriggerEnter2D(Collider2D collision)
    ///{
    // tagで識別する

    ///if (collision.CompareTag("Player") && collision.TryGetComponent(out CharactorBase charactor))
    ///{
    ///charactor.DamageBehaviour(m_bulletDamage);
    ///}
    ///}
}