using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    [SerializeField] EnemyDataBase _enemyDataBase;
    int totalEnemyCount = 0; �@�@//�E�F�[�u���̓G�̑���
    int activeEnemyCount = 0;�@�@//�o�����Ă���G�̑���
    int busteredEnemyCount = 0;�@//�E�F�[�u���œ|�����G�̐�

    // Start is called before the first frame update
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

    /// <summary>���I���\�b�h</summary>
    public int ChooseEnemy(EnemyData[] enemyData)
    {
        float[] weight = new float[enemyData.Length];

        for(int i = 0; i < enemyData.Length; i++)
        {
            weight[i] = enemyData[i].GetPopWight;
        }

        float total = 0f;
        //�z��̗v�f��total�ɑ��
        for (int i = 0; i < weight.Length; i++)
        {
            total += weight[i];
        }

        //Random.value��0.1����1�܂ł̒l��Ԃ�
        float random = UnityEngine.Random.value * total;

        //weight��random���傫������T��
        for (int i = 0; i < weight.Length; i++)
        {
            if (random < weight[i])
            {
                //�����_���̒l���d�݂��傫�������炻�̒l��Ԃ�
                return i;
            }
            else
            {
                //����weight�����������悤�ɂ���
                random -= weight[i];
            }
        }
        //�Ȃ�������Ō�̒l��Ԃ�
        return weight.Length;
    }
}
