using UnityEngine.UI;
using UnityEngine;

public class ChangeColorRGBA : MonoBehaviour
{
    private Slider _slider;
    public int _Inku;
    private int _maxhealth = 100;

    private void Start()
    {
        _slider = GetComponent<Slider>();//���̃R���|�[�l���g�����Ă���I�u�W�F�N�g���̃R���|�[�l���g���擾���邱�Ƃ��ł���
        _Inku = _maxhealth;
        _slider.maxValue = _maxhealth;
    }

    private void Update()
    {

    }
}