using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    // Start is called before the first frame update
    int totalEnemyCount = 0; 　　//ウェーブ毎の敵の総数
    int activeEnemyCount = 0;　　//出現している敵の総数
    int busteredEnemyCount = 0;　//ウェーブ内で倒した敵の数

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
}
