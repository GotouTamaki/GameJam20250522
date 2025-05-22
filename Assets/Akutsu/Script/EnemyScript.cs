using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : CharactorBase
{
	Rigidbody2D _rb;

	[SerializeField] GameObject _bullet;        //�e
	bool _isFoundPlayer = false;                //�v���C���[�w�c�𔭌����Ă��邩�H

	[SerializeField] float _bulletInterbal_sec = 3f;  //�e�̐����̃C���^�[�o������(�b)
	float _time = 0f;                               //�C���^�[�o���t���[���v���ϐ�
	float _second = 0f;                             //�C���^�[�o���b���v���ϐ�
	float baseSpeed = 1;

	// Start is called before the first frame update
	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		Application.targetFrameRate = 60;

	}
	// Update is called once per frame
	void Update()
	{
		if (!IsDead)
		{
			//�W�I����������A��~���Ēe�̐���
			if (_isFoundPlayer)
			{
				baseSpeed = 0;
				_second = _time++ / 30;

				//�C���^�[�o�����o�āA�e�̐���������
				if (_second > _bulletInterbal_sec)
				{
					_time = 0f;
					GameObject bullet = Instantiate(_bullet, this.transform.position, Quaternion.identity);
					bullet.GetComponent<EnemyBulletScript>()._attack = _charactorParamater.GetCharactorAttack;
				}
			}
			else baseSpeed = 1;

			//�������Ɉړ�
			this._rb.velocity = Vector2.left * baseSpeed * _charactorParamater.GetMoveSpeed;
		}
		else
		{
			OnDead();
		}
	}


	//�U���͈͓��̔���
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			_isFoundPlayer = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			_isFoundPlayer = false;
		}
	}
}
