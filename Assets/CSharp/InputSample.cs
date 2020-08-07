using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSample : MonoBehaviour
{
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Debug.LogFormat("({0}, {1})", h, v);

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1");
        }
    }
}
