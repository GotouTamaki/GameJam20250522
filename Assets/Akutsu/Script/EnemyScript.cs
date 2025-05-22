using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : CharactorBase
{
	Rigidbody2D _rb;

	[SerializeField] GameObject _bullet;        //弾
	bool _isFoundPlayer = false;                //プレイヤー陣営を発見しているか？

	[SerializeField] float _bulletInterbal_sec = 3f;  //弾の生成のインターバル時間(秒)
	float _time = 0f;                               //インターバルフレーム計測変数
	float _second = 0f;                             //インターバル秒数計測変数
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
			//標的を見つけたら、停止して弾の生成
			if (_isFoundPlayer)
			{
				baseSpeed = 0;
				_second = _time++ / 30;

				//インターバルを経て、弾の生成をする
				if (_second > _bulletInterbal_sec)
				{
					_time = 0f;
					GameObject bullet = Instantiate(_bullet, this.transform.position, Quaternion.identity);
					bullet.GetComponent<EnemyBulletScript>()._attack = _charactorParamater.GetCharactorAttack;
				}
			}
			else baseSpeed = 1;

			//左方向に移動
			this._rb.velocity = Vector2.left * baseSpeed * _charactorParamater.GetMoveSpeed;
		}
		else
		{
			OnDead();
		}
	}


	//攻撃範囲内の判定
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
