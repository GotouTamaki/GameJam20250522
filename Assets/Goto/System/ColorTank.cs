using UnityEngine;

[System.Serializable]
public class ColorTank
{
    [SerializeField] ColorType _colorType = ColorType.Blue;
    [SerializeField] int _maxTankValue = 50;  //100������ɕύX�\��
    [SerializeField] public int _currentTankValue = 0; //���݂�ColorValue

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
