using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    [SerializeField] EnemyDataBase _enemyDataBase;
    [SerializeField] Transform[] _popPoints;

    [SerializeField] private int totalEnemyCount = 10; �@�@//�E�F�[�u���̓G�̑���
    [SerializeField] private int _fieldEnemyLimit = 5;
    private int activeEnemyCount = 0;�@�@//�o�����Ă���G�̑���

    //���U���g�Ƃ��Ɏg������p�u���b�N
    public int busteredEnemyCount = 0;�@//�E�F�[�u���œ|�����G�̐�
    public int waveCount = 1;

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

        if (activeEnemyCount - busteredEnemyCount < _fieldEnemyLimit)
        {
            activeEnemyCount++;
            StartCoroutine(PopEnemy(ChooseEnemy(_enemyDataBase.GetEnemyData)));
        }
    }

    /// <summary>���I���\�b�h</summary>
    public int ChooseEnemy(EnemyData[] enemyData)
    {
        float[] weight = new float[enemyData.Length];

        for (int i = 0; i < enemyData.Length; i++)
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

    IEnumerator PopEnemy(int enemyDataLength)
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        Debug.Log("pop");
        Instantiate(_enemyDataBase.GetEnemyData[enemyDataLength].GetEnemy);
    }
}
