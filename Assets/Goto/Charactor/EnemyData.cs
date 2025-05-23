using UnityEngine;

[System.Serializable]
public class EnemyData
{
    [SerializeField] private CharactorBase _enemy;
    [SerializeField] private float _popTime;
    [SerializeField] private float _popWight;

    public@CharactorBase GetEnemy => _enemy;
    public float GetPopTime => _popTime;
    public float GetPopWight => _popWight;
}
