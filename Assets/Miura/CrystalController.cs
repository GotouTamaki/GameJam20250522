using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : CharactorBase
{
    [SerializeField] GameSystem gameSystem;

    [SerializeField] public float maxCrystalHP = 0;
    //[SerializeField] public float _CrystalHP = 0;

    bool isDisplay = false;

    //�N���X�^���̑ϋv�x��Wave���ɉ񕜂��H
    void Start()
    {
        //_hp = maxCrystalHP;
    }

    // Update is called once per frame
    void Update()
    {
        //if (IsDead)
        //{
        //    gameSystem.SetIsGameover(true); //GameSystem�ɏ������ڍs
        //    Debug.Log(gameSystem.GetIsGameOver);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            //collision.gameObject.GetComponent<>().bulletDamage; �G�̒e����_���[�W���擾
            //DamageBehaviour(float bulletDamage);
            if (IsDead && !isDisplay)
            {
                gameSystem.SetIsGameover(true); //GameSystem�ɏ������ڍs
                isDisplay = true;
            }
        }
    }

    // �_���[�W���󂯂郁�\�b�h
    /// <summary>
    /// ���\�b�h����Health <= 0 �ɂȂ��
    /// </summary>
}
