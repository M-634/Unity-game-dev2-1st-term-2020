using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーを動かす
/// </summary>
public class GhostController : MonoBehaviour
{
    [SerializeField] float m_speed = 5f;
    Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        m_rb.velocity = new Vector2(h * m_speed, v * m_speed);
    }
}
