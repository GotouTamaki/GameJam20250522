using UnityEngine;

public abstract class CharactorBase : MonoBehaviour
{
    [SerializeField] private int _hp = 1;
    [SerializeField] private float _charactorAttack = 1f;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _searchRange = 1f;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ParticleSystem _deadEffect;

    public bool IsDead => _hp < 0;

    public virtual void SetParameter(int hp, float charactorAttack, float moveSpeed, float searchRange)
    {
        _hp = hp;
        _charactorAttack = charactorAttack;
        _moveSpeed = moveSpeed;
        _searchRange = searchRange;
    }

    public virtual void OnInitialize()
    {
        _spriteRenderer.enabled = false;
    }

    public virtual void DamageBehaviour(int damage)
    {
        _hp -= damage;
    }

    public virtual void OnDead()
    {
        if (_deadEffect != null)
        {
            Instantiate(_deadEffect, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
