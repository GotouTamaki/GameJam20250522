using UnityEngine;

[System.Serializable]
public class CharactorParamater
{
    [SerializeField] private int _maxHp = 1;
    [SerializeField] private int _currentHp = 1;
    [SerializeField] private int _charactorAttack = 1;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _searchRange = 1f;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ParticleSystem _deadEffect;
    [SerializeField] private Collider2D _hitCollider;

    public int GetMaxHp => _maxHp;
    public int GetCurrentHp => _currentHp;
    public int GetCharactorAttack => _charactorAttack;
    public float GetMoveSpeed => _moveSpeed;
    public float GetSearchRange => _searchRange;
    public SpriteRenderer GetSpriteRenderer => _spriteRenderer;
    public ParticleSystem GetDeadEffect => _deadEffect;
    public Collider2D GetHitCollider => _hitCollider;

    public void SetMaxHp(int maxHp) => _maxHp = maxHp;
    public void SetHp(int hp) => _currentHp = hp;
    public void SetCharactorAttack(int charactorAttack) => _charactorAttack = charactorAttack;
    public void SetMoveSpeed(float moveSpeed) => _moveSpeed = moveSpeed;
    public void SetSearchRange(float searchRange) => _searchRange = searchRange;
    public void SetSpriteRenderer(SpriteRenderer spriteRenderer) => _spriteRenderer = spriteRenderer;
    public void SetDeadEffect(ParticleSystem deadEffect) => _deadEffect = deadEffect;
    public void SetHitCollider(Collider2D hitCollider) => _hitCollider = hitCollider;
}
