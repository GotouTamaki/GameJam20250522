using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    // Start is called before the first frame update
    int totalEnemyCount = 0; �@�@//�E�F�[�u���̓G�̑���
    int activeEnemyCount = 0;�@�@//�o�����Ă���G�̑���
    int busteredEnemyCount = 0;�@//�E�F�[�u���œ|�����G�̐�

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (busteredEnemyCount == totalEnemyCount) //�S�Ŕ���
        {
            //gameSystem.NextWave(); //Wave�̈ړ�
        }
    }
}
