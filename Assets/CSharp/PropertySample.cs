using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertySample : MonoBehaviour
{
    void Start()
    {
        string s = "CSharp";
        Debug.LogFormat("{0} の長さは {1} です。", s, s.Length);

        Vector2 v = new Vector2(1, 1);
        Debug.LogFormat("{0} のスカラー量は {1} です。", v, v.magnitude);
    }

    void Update()
    {

    }
}
