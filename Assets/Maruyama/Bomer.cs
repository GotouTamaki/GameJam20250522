using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomer : CharactorBase
{
    [SerializeField] ExplosionRange _explosionRange;

    // Start is called before the first frame update
    void Start()
    {
        _col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(_charactorParamater.GetMoveSpeed, 0, 0) * Time.deltaTime;
    }
    public override void OnDead()
    {
        base.OnDead();
        //Instantiate(this);
    }

    Collider2D  _col;

    private void col()
    {
        _col = GetComponent<Collider2D>();
        _col.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 爆発範囲用のオブジェクトを生成する
        ExplosionRange range = Instantiate(_explosionRange, transform.position, transform.rotation);
        DamageBehaviour(_charactorParamater.GetMaxHp);
    }
}
