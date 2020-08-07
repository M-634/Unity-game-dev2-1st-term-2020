using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class varSample : MonoBehaviour
{
    void Start()
    {
        Vector2[] v2Array = { Vector2.up, Vector2.down, Vector2.right, Vector2.left };

        // 配列変数 v2Array のすべての要素に対してループする
        foreach (var v2 in v2Array) // v2Array の要素を一つずつ変数 v2 に格納してループさせる。この場合、型は指定しなくとも Vector2 に決まっているので、型を var と指定できる。
        {
            Debug.Log(v2);
        }
    }

    void Update()
    {

    }
}
