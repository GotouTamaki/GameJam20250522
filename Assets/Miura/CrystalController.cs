using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : CharactorBase
{
    [SerializeField] GameSystem gameSystem;

    [SerializeField] public float maxCrystalHP = 0;
    //[SerializeField] public float _CrystalHP = 0;

    bool isDisplay = false;

    //クリスタルの耐久度はWave毎に回復か？
    void Start()
    {
        //_hp = maxCrystalHP;
    }

    // Update is called once per frame
    void Update()
    {
        //if (IsDead)
        //{
        //    gameSystem.SetIsGameover(true); //GameSystemに処理が移行
        //    Debug.Log(gameSystem.GetIsGameOver);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            //collision.gameObject.GetComponent<>().bulletDamage; 敵の弾からダメージを取得
            //DamageBehaviour(float bulletDamage);
            if (IsDead && !isDisplay)
            {
                gameSystem.SetIsGameover(true); //GameSystemに処理が移行
                isDisplay = true;
            }
        }
    }

    // ダメージを受けるメソッド
    /// <summary>
    /// メソッド内でHealth <= 0 になれば
    /// </summary>
}
