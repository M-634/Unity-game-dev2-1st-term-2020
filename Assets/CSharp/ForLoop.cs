using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLoop : MonoBehaviour
{
    void Start()
    {
        Debug.Log("単純に決まった回数繰り返す");
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("a");
        }

        // 配列を宣言する
        string[] array = { "strawberry", "banana", "apple", "orange", "kiwi" };

        Debug.Log("順番に出力する");
        for (int i = 0; i < array.Length; i++)  // ここで i をもう一度使っても問題ない
        {
            Debug.Log(array[i]);
        }

        Debug.Log("逆順に出力する");
        for (int i = array.Length - 1; i > -1; i--)
        {
            Debug.Log(array[i]);
        }

        Debug.Log("foreach を使って出力する");
        foreach (string s in array)
        {
            Debug.Log(s);
        }
    }

    void Update()
    {

    }
}
