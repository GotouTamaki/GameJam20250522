using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    [SerializeField] EnemyDataBase _enemyDataBase;
    int totalEnemyCount = 0; 　　//ウェーブ毎の敵の総数
    int activeEnemyCount = 0;　　//出現している敵の総数
    int busteredEnemyCount = 0;　//ウェーブ内で倒した敵の数

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (busteredEnemyCount == totalEnemyCount) //全滅判定
        {
            //gameSystem.NextWave(); //Waveの移動
        }
    }

    /// <summary>抽選メソッド</summary>
    public int ChooseEnemy(EnemyData[] enemyData)
    {
        float[] weight = new float[enemyData.Length];

        for(int i = 0; i < enemyData.Length; i++)
        {
            weight[i] = enemyData[i].GetPopWight;
        }

        float total = 0f;
        //配列の要素をtotalに代入
        for (int i = 0; i < weight.Length; i++)
        {
            total += weight[i];
        }

        //Random.valueは0.1から1までの値を返す
        float random = UnityEngine.Random.value * total;

        //weightがrandomより大きいかを探す
        for (int i = 0; i < weight.Length; i++)
        {
            if (random < weight[i])
            {
                //ランダムの値より重みが大きかったらその値を返す
                return i;
            }
            else
            {
                //次のweightが処理されるようにする
                random -= weight[i];
            }
        }
        //なかったら最後の値を返す
        return weight.Length;
    }
}
