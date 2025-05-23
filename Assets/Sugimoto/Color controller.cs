using UnityEngine.UI;
using UnityEngine;

public class ChangeColorRGBA : MonoBehaviour
{
    private Slider _slider;
    public int _Inku;
    private int _maxhealth = 100;

    private void Start()
    {
        _slider = GetComponent<Slider>();//このコンポーネントがついているオブジェクト内のコンポーネントを取得することができる
        _Inku = _maxhealth;
        _slider.maxValue = _maxhealth;
    }

    private void Update()
    {

    }
}