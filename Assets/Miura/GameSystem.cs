using UnityEngine;

public enum GameMode
{
    None,
    Wave,
    Endless,
}
public enum ColorType
{
    Red,
    Blue,
    Yellow,
}

// ダメージ計算とダメージの処理(HP)
// Animationと効果音

public class GameSystem : MonoBehaviour
{
    // クリア条件・失敗条件・Wave移行条件
    public ColorTank[] allColoersTank;
    GameMode gameMode = GameMode.None;

    [SerializeField] ResultUI resultUI;

    bool _isGameOver;

    int mustEnemyCount = 0;
    int currentEnemyCount = 0;
    int makedEnemycount = 0;

    int currentWaveNumber = 1;
    float useSkillValue = 0; // スキル発動に必要な色の使用量

    bool[] activeSkillUI = { false, false, false };

    float maxColorValue;    // 色値の最大保有量

    CrystalController crystalController;

    public bool GetIsGameOver // プロパティ
    {
        get { return _isGameOver; }
    }

    public void SetIsGameover(bool isGameOver)
    {
        _isGameOver = isGameOver;

        if (isGameOver)
        {
            resultUI.OnResultDisplay();
        }
    }

    void Start()
    {
        ChangeWave(currentWaveNumber); //EnemyManagerのメソッドを呼ぶ。
    }

    void ChangeWave(int i)
    {
        //ウェーブ情報の初期化
        //他のクラスからウェーブ毎に決められた敵の総数・出現間隔などのデータを取得
        //取得したデータを変数に代入し、敵を生成
        //生成だけ出来ればEnemyManagerにてWaveの移行条件は判断することができる。
    }

    void NextWave()
    {
        //NextWaveに行く処理
        currentWaveNumber++;
        ChangeWave(currentWaveNumber); //currentWaveNumberに応じてWaveの情報が入っているメソッドを呼び出してくる →　ChangeWave()でここのスクリプトにある EnemyCount系 を変更する。
        if (currentWaveNumber >= 11)
        {
            GameClear();
        }
    }

    void GameClear()
    {
        //Textの表示　→Text + Image オブジェクト(ゲームクリアUIオブジェクト)の生成
        //画像の表示
        //効果音の発生
        //タイトルへ戻るボタンの表示　
        //リスタートボタンの表示　　　
    }

    // 色の加算 と スキルUIのアクティブ判定
    public void AddColoerValue(int getColorValue, ColorType colorType) //色の判断が必要
    {
        int colorTypeIndex = -1;

        switch (colorType)
        {
            case ColorType.Red:
                colorTypeIndex = 0;
                break;
            case ColorType.Blue:
                colorTypeIndex = 1;
                break;
            case ColorType.Yellow:
                colorTypeIndex = 2;
                break;
        }
        if (colorTypeIndex != -1)
        {
            allColoersTank[colorTypeIndex]._currentTankValue += getColorValue; 　　//色の加算

            if (allColoersTank[colorTypeIndex]._currentTankValue >= useSkillValue) //色に応じたスキルUIのアクティブ判定
            {
                activeSkillUI[colorTypeIndex] = true;
            }
        }
        else if (colorTypeIndex == -1)
        {
            Debug.LogError("ColorTypeが割り当てられていない");
        }
    }


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

    }
}
