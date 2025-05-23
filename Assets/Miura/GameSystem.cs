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

// �_���[�W�v�Z�ƃ_���[�W�̏���(HP)
// Animation�ƌ��ʉ�

public class GameSystem : MonoBehaviour
{
    // �N���A�����E���s�����EWave�ڍs����
    public ColorTank[] allColoersTank;
    GameMode gameMode = GameMode.None;

    [SerializeField] ResultUI resultUI;

    bool _isGameOver;

    int mustEnemyCount = 0;
    int currentEnemyCount = 0;
    int makedEnemycount = 0;

    int currentWaveNumber = 1;
    float useSkillValue = 0; // �X�L�������ɕK�v�ȐF�̎g�p��

    bool[] activeSkillUI = { false, false, false };

    float maxColorValue;    // �F�l�̍ő�ۗL��

    CrystalController crystalController;

    public bool GetIsGameOver // �v���p�e�B
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
        ChangeWave(currentWaveNumber); //EnemyManager�̃��\�b�h���ĂԁB
    }

    void ChangeWave(int i)
    {
        //�E�F�[�u���̏�����
        //���̃N���X����E�F�[�u���Ɍ��߂�ꂽ�G�̑����E�o���Ԋu�Ȃǂ̃f�[�^���擾
        //�擾�����f�[�^��ϐ��ɑ�����A�G�𐶐�
        //���������o�����EnemyManager�ɂ�Wave�̈ڍs�����͔��f���邱�Ƃ��ł���B
    }

    void NextWave()
    {
        //NextWave�ɍs������
        currentWaveNumber++;
        ChangeWave(currentWaveNumber); //currentWaveNumber�ɉ�����Wave�̏�񂪓����Ă��郁�\�b�h���Ăяo���Ă��� ���@ChangeWave()�ł����̃X�N���v�g�ɂ��� EnemyCount�n ��ύX����B
        if (currentWaveNumber >= 11)
        {
            GameClear();
        }
    }

    void GameClear()
    {
        //Text�̕\���@��Text + Image �I�u�W�F�N�g(�Q�[���N���AUI�I�u�W�F�N�g)�̐���
        //�摜�̕\��
        //���ʉ��̔���
        //�^�C�g���֖߂�{�^���̕\���@
        //���X�^�[�g�{�^���̕\���@�@�@
    }

    // �F�̉��Z �� �X�L��UI�̃A�N�e�B�u����
    public void AddColoerValue(int getColorValue, ColorType colorType) //�F�̔��f���K�v
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
            allColoersTank[colorTypeIndex]._currentTankValue += getColorValue; �@�@//�F�̉��Z

            if (allColoersTank[colorTypeIndex]._currentTankValue >= useSkillValue) //�F�ɉ������X�L��UI�̃A�N�e�B�u����
            {
                activeSkillUI[colorTypeIndex] = true;
            }
        }
        else if (colorTypeIndex == -1)
        {
            Debug.LogError("ColorType�����蓖�Ă��Ă��Ȃ�");
        }
    }


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

    }
}
