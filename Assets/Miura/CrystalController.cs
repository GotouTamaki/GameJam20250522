using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrystalController : CharactorBase
{
    [SerializeField] GameSystem gameSystem;

    [SerializeField] public float maxCrystalHP = 0;
    //[SerializeField] public float _CrystalHP = 0;



    //クリスタルの耐久度はWave毎に回復か？
    void Start()
    {
        //_hp = maxCrystalHP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            //collision.gameObject.GetComponent<>().bulletDamage; 敵の弾からダメージを取得
            //DamageBehaviour(float bulletDamage);
            if (IsDead)
            {
                gameSystem.SetIsGameover(true); //GameSystemに処理が移行
            }
        }
    }

    // ダメージを受けるメソッド
    /// <summary>
    /// メソッド内でHealth <= 0 になれば
    /// </summary>
}
