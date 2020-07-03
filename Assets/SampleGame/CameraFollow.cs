using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラを Player に追従させる
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [SerializeField] float m_smoothTime = 0f;
    Transform m_player;
    Vector3 m_velocity = Vector3.zero;

    void LateUpdate()
    {
        if (m_player)
        {
            Vector3 target = new Vector3(m_player.position.x, m_player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, target, ref m_velocity, m_smoothTime);
        }
        else
        {
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            if (go)
            {
                m_player = go.transform;
            }
        }
    }
}
