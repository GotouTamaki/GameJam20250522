using UnityEngine;
public class EnemyAimAtAlly : CharactorBase
{
	Rigidbody2D _rb;
	[SerializeField] GameSystem gameSystem;

	[SerializeField] protected GameObject _bullet;        //弾
	[SerializeField] protected Transform _muzzleTransform;
	protected bool _isFoundPlayer = false;                //プレイヤー陣営を発見しているか？

	[SerializeField] float _bulletInterbal_sec = 3f;  //弾の生成のインターバル時間(秒)
	[SerializeField] float _baseSpeed = 1;            //弾のスピード
	[SerializeField] ColorType colorType;

	//float _time = 0f;                               //インターバルフレーム計測変数
	//float _second = 0f;                             //インターバル秒数計測変数
	float _duration;
    public int giveColorValue = 0;                   //ColorTankに与える色の値
    protected Vector3 _targetDirection;

	bool _isdead = false;


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
			//標的を見つけたら、停止して弾の生成
			if (_isFoundPlayer)
			{
				_baseSpeed = 0;
				//_second = _time++ / 30;

				//インターバルを経て、弾の生成をする
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

			//左方向に移動
			this._rb.velocity = Vector2.left * _baseSpeed * _charactorParamater.GetMoveSpeed;
		}
		else
		{
			if (!_isdead)
			{
				_isdead = true;
				OnDead();
				gameSystem.AddColoerValue(giveColorValue, colorType);//初期値
			}
        }
	}


	//攻撃範囲内の判定
	protected virtual void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.tag == "Player") //味方だったらダメージ　→　Player側のスクリプトは逆になる。
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

	void OnDestroy() //いらない
	{
        //Colortunkに色を追加
        //int getColorValue, ColorType colorType
        //gameSystem.AddColoerValue()

    }

	public virtual void OnDead()
	{
		base.OnDead();
        FindAnyObjectByType<EnemyManager>().busteredEnemyCount++;
    }
}
