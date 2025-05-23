using UnityEngine;
using UnityEngine.UI; // UI�֘A���g�p���邽�߂ɕK�v

public class PlayerHealth : MonoBehaviour
{
    private Slider _slider;
    public int _health;
    private int _maxhealth = 100;

    private void Start()
    {
        _slider = GetComponent<Slider>();//���̃R���|�[�l���g�����Ă���I�u�W�F�N�g���̃R���|�[�l���g���擾���邱�Ƃ��ł���
        _health = _maxhealth;
        _slider.maxValue = _maxhealth;
    }

    private void Update()
    {
        _slider.value = _health;
    }
}