using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
	/// <summary>’e‚ª”ò‚Ô‘¬‚³</summary>
	[SerializeField] float _speed = 3f;
	/// <summary>’e‚Ì¶‘¶ŠúŠÔi•bj</summary>
	[SerializeField] float _lifeTime = 3f;

	// Start is called before the first frame update
	void Start()
	{
		// ‰E•ûŒü‚É”ò‚Î‚·
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.velocity = Vector2.left * _speed;

		// ¶‘¶ŠúŠÔ‚ªŒo‰ß‚µ‚½‚ç©•ª©g‚ğ”jŠü‚·‚é
		Destroy(this.gameObject, _lifeTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			Destroy(this.gameObject);
		}
	}
}
