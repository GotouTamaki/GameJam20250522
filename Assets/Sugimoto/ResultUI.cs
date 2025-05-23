using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // UI�֘A���g�p���邽�߂ɕK�v

public class ResultUI : MonoBehaviour
{
    [SerializeField] GameObject _resultPanel;
    [SerializeField] TextMeshProUGUI _TextMeshPro;
    [SerializeField] GameSystem _gameSystem;
    [SerializeField] EnemyManager _enemyManager;

    private void OnEnable()
    {
        _resultPanel.SetActive(false);
    }

    public void OnResultDisplay()
    {
        if (_gameSystem.GetIsGameOver)
        {
            _resultPanel.SetActive(true);
            //kill����Wave����\��
            _TextMeshPro.text = $"Game over \n Survival Wave{_enemyManager.waveCount}\n Kill{_enemyManager.busteredEnemyCount}";
            Debug.Log("Result" + _gameSystem.GetIsGameOver);
        }
    }
}
