using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] Animator m_anim;
    [SerializeField] string m_parameter;

    // Start is called before the first frame update
    void Start()
    {
        m_anim = m_anim.gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_anim.SetTrigger(m_parameter);
        }
    }
}
