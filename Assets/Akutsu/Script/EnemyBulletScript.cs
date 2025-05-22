using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
	/// <summary>�e����ԑ���</summary>
	[SerializeField] float _speed = 3f;
	/// <summary>�e�̐������ԁi�b�j</summary>
	[SerializeField] float _lifeTime = 3f;

	public int _attack;

	// Start is called before the first frame update
	void Start()
	{
		// �E�����ɔ�΂�
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.velocity = Vector2.left * _speed;

		// �������Ԃ��o�߂����玩�����g��j������
		Destroy(this.gameObject, _lifeTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			Destroy(this.gameObject);
			if (collision.TryGetComponent<CharactorBase>(out var CharactorBase))
			{
				CharactorBase.DamageBehaviour(_attack);
			}
		}
	}
}
