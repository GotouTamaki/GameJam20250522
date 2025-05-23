using UnityEngine;
using UnityEngine.UI; // UI関連を使用するために必要
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
