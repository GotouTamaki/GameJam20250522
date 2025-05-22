using UnityEngine;

public abstract class CharactorBase : MonoBehaviour
{
    [SerializeField] protected CharactorParamater _charactorParamater;

    public CharactorParamater GetCharactorParamater => _charactorParamater;

    public bool IsDead => _charactorParamater.GetCurrentHp < 0;

    public virtual void SetParameter(int maxHp, int hp, float charactorAttack, float moveSpeed, float searchRange)
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
        if (_charactorParamater.GetDeadEffect != null)
        {
            Instantiate(_charactorParamater.GetDeadEffect, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
