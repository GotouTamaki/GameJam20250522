using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SC : MonoBehaviour
{
    [SerializeField] int _hp = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Bullet")
		{
			_hp--;

			if (_hp <= 0) Destroy(this.gameObject);
		}
	}
}
