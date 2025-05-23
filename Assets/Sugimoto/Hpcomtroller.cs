using UnityEngine;
using UnityEngine.UI; // UI関連を使用するために必要

public class PlayerHealth : MonoBehaviour
{
    private Slider _slider;
    public int _health;
    private int _maxhealth = 100;

    private void Start()
    {
        _slider = GetComponent<Slider>();//このコンポーネントがついているオブジェクト内のコンポーネントを取得することができる
        _health = _maxhealth;
        _slider.maxValue = _maxhealth;
    }

    private void Update()
    {
        _slider.value = _health;
    }
}