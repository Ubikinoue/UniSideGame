using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletController : MonoBehaviour
{
    //���˂���폜�����܂ł̎���
    public float deleteTime = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�j������^�C�~���O��ݒ肵�Ă���
        Destroy(gameObject, this.deleteTime); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
