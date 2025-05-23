using UnityEngine;

public class EnemyAimAtAlly : CharactorBase
{
	Rigidbody2D _rb;

	[SerializeField] protected GameObject _bullet;        //�e
	[SerializeField] protected Transform _muzzleTransform;
	 protected bool _isFoundPlayer = false;                //�v���C���[�w�c�𔭌����Ă��邩�H

	[SerializeField] float _bulletInterbal_sec = 3f;  //�e�̐����̃C���^�[�o������(�b)
	//float _time = 0f;                               //�C���^�[�o���t���[���v���ϐ�
	//float _second = 0f;                             //�C���^�[�o���b���v���ϐ�
	float _baseSpeed = 1;
	float _duration;
    protected Vector3 _targetDirection;

    // Start is called before the first frame update
    void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
        //Application.targetFrameRate = 60;
        _duration = _bulletInterbal_sec;
    }

	// Update is called once per frame
	void Update()
	{
		if (!IsDead)
		{
			//�W�I����������A��~���Ēe�̐���
			if (_isFoundPlayer)
			{
				_baseSpeed = 0;
				//_second = _time++ / 30;

				//�C���^�[�o�����o�āA�e�̐���������
				if (Time.time - _duration > _bulletInterbal_sec)
				{
					//_time = 0f;
					GameObject bullet = Instantiate(_bullet, _muzzleTransform.position, _muzzleTransform.rotation);
					var enemyBullet = bullet.GetComponent<EnemyBulletScript>();
					enemyBullet._bulletAttack = _charactorParamater.GetCharactorAttack;
					enemyBullet.OnInitialize(_targetDirection, _charactorParamater.GetCharactorAttack);
					_duration = Time.time;
				}
			}
			else
			{
				_baseSpeed = 1;
			}

			//�������Ɉړ�
			this._rb.velocity = Vector2.left * _baseSpeed * _charactorParamater.GetMoveSpeed;
		}
		else
		{
			OnDead();
		}
	}


	//�U���͈͓��̔���
	protected virtual void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			_isFoundPlayer = true;
            _targetDirection = (collision.transform.position - _muzzleTransform.position).normalized;
            //_muzzleTransform.rotation = Quaternion.Euler(_targetDirection);
        }
	}

    protected virtual void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			_isFoundPlayer = false;
		}
	}
}
