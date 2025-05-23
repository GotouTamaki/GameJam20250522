using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private CrystalController _crystalController;
    [SerializeField] private ColorTank[] _colorTanks;

    private bool _isGameOver;

    public bool IsGameOver => _isGameOver;

    public void SetIsGameOver(bool isGameOver)
    {
        _isGameOver = isGameOver;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
