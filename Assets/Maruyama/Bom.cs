using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    [SerializeField, Header("Speed")]
    private float speed = -1.0f;
    //float speed = -1.0f;    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0) * Time.deltaTime;
    }
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hitObj = collision.gameObject; //当たったオブジェクトを取得
        switch (hitObj.tag)
        {

        }
    } */

}
