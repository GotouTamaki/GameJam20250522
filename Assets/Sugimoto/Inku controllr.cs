using UnityEngine;
using UnityEngine.UI; // UI�֘A���g�p���邽�߂ɕK�v
public class Inkucontrollr : MonoBehaviour
{
    [SerializeField] private Slider _redSlider;
    [SerializeField] private Slider _bleuSlider;
    [SerializeField] private Slider _yellowSlider;
    private bool hasProcessed;
    public int _Inku;
    private int _maxhealth = 100;

    private void Start()
    {
        _Inku = _maxhealth;
    }

    private void Update()
    {

    }

}
