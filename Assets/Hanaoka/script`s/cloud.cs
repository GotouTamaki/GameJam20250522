using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CloudMove : MonoBehaviour
{
    public float speed = 1f; // 移動速度
    public float resetPositionX = -10f; // 雲が消える位置
    public float startPositionX = 10f;  // 雲が出てくる位置

    void Update()
    {
        // 左に移動
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // もし左端よりも左に行ったら
        if (transform.localPosition.x < resetPositionX)
        {
            // 右端に戻す
            Vector3 pos = transform.localPosition;
            pos.x = startPositionX;
            transform.localPosition = pos;
        }
    }
}