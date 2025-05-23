using UnityEngine;
using UnityEngine.UI; // UI関連を使用するために必要
public class Inkucontrollr : MonoBehaviour
{
    [SerializeField] private Slider _redSlider;
    [SerializeField] private Slider _bleuSlider;
    [SerializeField] private Slider _yellowSlider;
    private int _maxhealth = 100;
    [Range(0, 100)] public int _redhealth;
    [Range(0, 100)] public int _bleuhealth;
    [Range(0, 100)] public int _yellowhealth;

    private void Start()
    {
        _redhealth = _maxhealth;
        _bleuhealth = _maxhealth;
        _yellowhealth = _maxhealth;

        _redSlider.maxValue = _maxhealth;
        _bleuSlider.maxValue = _maxhealth;
        _yellowSlider.maxValue = _maxhealth;
    }

    private void Update()
    {
        _redSlider.value = _redhealth;
        _bleuSlider.value = _bleuhealth;
        _yellowSlider.value = _yellowhealth;
    }

}
