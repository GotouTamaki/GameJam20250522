using UnityEngine;
using UnityEngine.UI; // UI関連を使用するために必要

public class PlayerHealth : MonoBehaviour
{
    private Slider _slider;
    public int _health;
    [SerializeField] CrystalController _controller;
    private int _maxhealth;
    private void Start()
    {
        _slider = GetComponent<Slider>();//このコンポーネントがついているオブジェクト内のコンポーネントを取得することができる
        _maxhealth = _controller.GetCharactorParamater.GetMaxHp;
        _health = _controller.GetCharactorParamater.GetCurrentHp;
        _slider.maxValue = _maxhealth;
    }

    private void Update()
    {
        if (_health != 0 && _maxhealth != 0)
        {
            _slider.value = _health / _maxhealth;
        }
    }
}