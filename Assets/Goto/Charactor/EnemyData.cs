using UnityEngine;

[System.Serializable]
public class EnemyData
{
    [SerializeField] private CharactorBase _enemy;
    [SerializeField] private float _popTime;

    public@CharactorBase GetEnemy => _enemy;
    public float GetPopTime => _popTime;
}
