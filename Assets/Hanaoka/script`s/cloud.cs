using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CloudMove : MonoBehaviour
{
    public float speed = 1f; // �ړ����x
    public float resetPositionX = -10f; // �_��������ʒu
    public float startPositionX = 10f;  // �_���o�Ă���ʒu

    void Update()
    {
        // ���Ɉړ�
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // �������[�������ɍs������
        if (transform.localPosition.x < resetPositionX)
        {
            // �E�[�ɖ߂�
            Vector3 pos = transform.localPosition;
            pos.x = startPositionX;
            transform.localPosition = pos;
        }
    }
}