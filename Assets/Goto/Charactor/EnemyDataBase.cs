using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataBase", menuName = "Scriptable Objects/EnemyDataBase")]
public class EnemyDataBase : ScriptableObject
{
    [SerializeField] private EnemyData[] _enemyData;

    public EnemyData[] GetEnemyData => _enemyData;
}
