using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float _speed = 1f; //Enemy�̑���
    Rigidbody2D _rb;

    [SerializeField] GameObject _bullet;        //�e
    bool _isFoundPlayer = false;                //�v���C���[�w�c�𔭌����Ă��邩�H

    [SerializeField] float _bulletInterbal_sec = 3f;  //�e�̐����̃C���^�[�o������(�b)
    float _time = 0f;                               //�C���^�[�o���t���[���v���ϐ�
    float _second = 0f;                             //�C���^�[�o���b���v���ϐ�

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
	}

    // Update is called once per frame
    void Update()
    {
        float baseSpeed = 1;

        //�W�I����������A��~���Ēe�̐���
        if (_isFoundPlayer)
        {
            baseSpeed = 0;
            _second = _time++ / 30;

            //�C���^�[�o�����o�āA�e�̐���������
            if (_second > _bulletInterbal_sec)
            {
				_time = 0f;
				Instantiate(_bullet, this.transform.position, Quaternion.identity);
            }
		}

        //�������Ɉړ�
        this._rb.velocity = Vector2.left * baseSpeed * _speed;
	}

    //����͈͂�Player������Ȃ�~�܂�ݒ�
    //���Ȃ��Ȃ�A�ړ�
	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.tag == "Player")
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
