using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : CharactorBase
{
    Rigidbody2D _rb;

    [SerializeField] GameObject _bullet;
    bool _isFoundPlayer = false;

    [SerializeField] float _bulletInterbal_sec = 3f;
    float _time = 0f;
    float _second = 0f;
    float baseSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
