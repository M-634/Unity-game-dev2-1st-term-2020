using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ricorisu : MonoBehaviour
{
    [SerializeField] float m_movingSpeed = 5f;
    [SerializeField] Animator m_anim;
    Rigidbody m_rb;


    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 velo = new Vector3(h, 0, v) * m_movingSpeed;
        velo.y = m_rb.velocity.y;
        //Rigidbodyのvelocityで動かすには、colliderをアタッチしなければならない！
        //忘れやすいので注意！！
        m_rb.velocity = velo;
       
        if (m_anim)
        {
            m_anim.SetFloat("Speed", velo.magnitude);
        }
    }
}
