using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    [SerializeField] EnemyDataBase _enemyDataBase;
    [SerializeField] Transform[] _popPoints;

    [SerializeField] private int totalEnemyCount = 10; 　　//ウェーブ毎の敵の総数
    [SerializeField] private int _fieldEnemyLimit = 5;
    private int activeEnemyCount = 0;　　//出現している敵の総数

    //リザルトとかに使うからパブリック
    public int busteredEnemyCount = 0;　//ウェーブ内で倒した敵の数
    public int waveCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        WaveInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (busteredEnemyCount == totalEnemyCount) //全滅判定
        {
            //gameSystem.NextWave(); //Waveの移動
        }
    }

    public void WaveInit()
    {
        activeEnemyCount = 0;
        busteredEnemyCount = 0;
        waveCount++;

        StartCoroutine(StartWave());
    }

    /// <summary>抽選メソッド</summary>
    public int ChooseEnemy(EnemyData[] enemyData)
    {
        float[] weight = new float[enemyData.Length];

        for (int i = 0; i < enemyData.Length; i++)
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

    /// <summary>
    /// ウェーブ初めにエネミー
    /// </summary>
    /// <returns></returns>
    IEnumerator StartWave()
    {
        Debug.Log("Start");
        while (true)
        {
            if (activeEnemyCount - busteredEnemyCount < _fieldEnemyLimit)
            {
                activeEnemyCount++;
                int enemyIndex = ChooseEnemy(_enemyDataBase.GetEnemyData);
                PopEnemy(enemyIndex);
            }

            // ランダムな時間を待つ（例：1〜3秒）
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    /// <summary>
    /// エネミーを出現させる
    /// </summary>
    /// <param name="enemyDataLength"></param>
    /// <returns></returns>
    private void PopEnemy(int enemyDataLength)
    {
        Debug.Log("pop");
        Instantiate(_enemyDataBase.GetEnemyData[enemyDataLength].GetEnemy);
    }
}
