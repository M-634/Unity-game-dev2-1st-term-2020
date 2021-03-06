﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LizardController : MonoBehaviour
{
    /// <summary>動く速さ</summary>
    [SerializeField] float m_movingSpeed = 5f;
    /// <summary>ターンの速さ</summary>
    [SerializeField] float m_turnSpeed = 3f;
    /// <summary>ジャンプ力</summary>
    [SerializeField] float m_jumpPower = 5f;
    /// <summary>羽ばたく力</summary>
    [SerializeField] float m_flapPower = 5f;
    /// <summary>接地判定の際、中心 (Pivot) からどれくらいの距離を「接地している」と判定するかの長さ</summary>
    [SerializeField] float m_isGroundedLength = 1.1f;
    /// <summary>キャラクターの Animator</summary>
    [SerializeField] Animator m_anim;

    bool m_isFire;
    Rigidbody m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 方向の入力を取得する
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        // 攻撃中は動かない
        if (!m_isFire)
        {
            // 左右で回転させる
            if (h != 0)
            {
                this.transform.Rotate(this.transform.up, h * m_turnSpeed);
            }

            // 上下で前後移動する。ジャンプした時の y 軸方向の速度は保持する。

            Vector3 velo = this.transform.forward * m_movingSpeed * v;
            velo.y = m_rb.velocity.y;
            m_rb.velocity = velo;
        }

        // Animator Controller のパラメータをセットする
        if (m_anim)
        {
            // 攻撃ボタンを押された時の処理
            if (Input.GetButton("Fire1") && IsGrounded())
            {
                m_anim.SetBool("Fire", true);
                m_isFire = true;
            }
            else
            {
                m_anim.SetBool("Fire", false);
                m_isFire = false;
            }

            // 水平方向の速度を Speed にセットする
            Vector3 velocity = m_rb.velocity;
            velocity.y = 0f;
            m_anim.SetFloat("Speed", velocity.magnitude);

            // 地上/空中の状況に応じて IsGrounded をセットする
            if (m_rb.velocity.y <= 0f && IsGrounded())
            {
                m_anim.SetBool("IsGrounded", true);
            }
            else if (!IsGrounded())
            {
                m_anim.SetBool("IsGrounded", false);
            }

            // 旋回
            if (h == 0)
            {
                m_anim.SetBool("Turn", false);
            }
            else
            {
                m_anim.SetBool("Turn", true);
            }
        }

        // ジャンプの入力を取得し、接地している時に押されていたらジャンプする
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            m_rb.AddForce(Vector3.up * m_jumpPower, ForceMode.Impulse);

            // Animator Controller のパラメータをセットする
            if (m_anim)
            {
                m_anim.SetBool("IsGrounded", false);
            }
        }

        if (Input.GetButton("Jump") && !IsGrounded())
        {
            m_rb.AddForce(Vector3.up * m_flapPower);
        }
    }

    /// <summary>
    /// 地面に接触しているか判定する
    /// </summary>
    /// <returns></returns>
    bool IsGrounded()
    {
        // Physics.Linecast() を使って足元から線を張り、そこに何かが衝突していたら true とする
        CapsuleCollider col = GetComponent<CapsuleCollider>();
        Vector3 start = this.transform.position + col.center;   // start: 体の中心
        Vector3 end = start + Vector3.down * m_isGroundedLength;  // end: start から真下の地点
        Debug.DrawLine(start, end); // 動作確認用に Scene ウィンドウ上で線を表示する
        bool isGrounded = Physics.Linecast(start, end); // 引いたラインに何かがぶつかっていたら true とする
        return isGrounded;
    }
}
