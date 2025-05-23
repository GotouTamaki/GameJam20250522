using UnityEngine;

public class ColorTank
{
    [SerializeField] ColorType _colorType = ColorType.Blue;
    [SerializeField] int _maxTankValue = 50;
    [SerializeField] int _currentTankValue = 0;

    public ColorType ColorType => ColorType;
    public int maxTabkValure => _maxTankValue;
    public int CurrentTabkValure => _currentTankValue;

    public void AddCurrentTankValue(int value)
    {
        _currentTankValue += value;

        if (_currentTankValue > _maxTankValue)
        {
            _currentTankValue = _maxTankValue;
        }
    }
}
