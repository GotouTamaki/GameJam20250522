using UnityEngine;

public class CharactorBase : MonoBehaviour
{
    [SerializeField] protected CharactorParamater _charactorParamater;
    [SerializeField] protected Rigidbody2D _rigidbody2D;

    public CharactorParamater GetCharactorParamater => _charactorParamater;

    public bool IsDead => _charactorParamater.GetCurrentHp <= 0;

    public virtual void SetParameter(int maxHp, int hp, int charactorAttack, float moveSpeed, float searchRange)
    {
        _charactorParamater.SetMaxHp(maxHp);
        _charactorParamater.SetHp(hp);
        _charactorParamater.SetCharactorAttack(charactorAttack);
        _charactorParamater.SetMoveSpeed(moveSpeed);
        _charactorParamater.SetSearchRange(searchRange);
    }

    public virtual void OnInitialize()
    {
        _charactorParamater.GetSpriteRenderer.enabled = false;
    }

    public virtual void DamageBehaviour(int damage)
    {
        _charactorParamater.SetHp(_charactorParamater.GetCurrentHp - damage);
    }

    public virtual void OnDead()
    {
        if(_rigidbody2D != null)
        {
            //_rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
            //_rigidbody2D.Sleep();
        }

        if (_charactorParamater.GetSpriteRenderer != null)
        {
            _charactorParamater.GetSpriteRenderer.enabled = false;
        }

        if (_charactorParamater.GetHitCollider != null)
        {
            _charactorParamater.GetHitCollider.enabled = false;
        }

        if (_charactorParamater.GetDeadEffect != null)
        {
            Instantiate(_charactorParamater.GetDeadEffect, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
