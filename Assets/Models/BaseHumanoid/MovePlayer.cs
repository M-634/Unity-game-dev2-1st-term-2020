using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] float m_speed = 2f;
    Vector3 m_latestPos; 
    Rigidbody m_rb;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = transform.position - m_latestPos;   //前回からどこに進んだかをベクトルで取得
        m_latestPos = transform.position;  //前回のPositionの更新

        //ベクトルの大きさが0.01以上の時に向きを変える処理をする
        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
        }

        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 velo = new Vector3(h, 0, v).normalized;
        m_rb.velocity = velo * m_speed;

    }
}
