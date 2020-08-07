using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeSample : MonoBehaviour
{
    void Start()
    {
        int a = 1 + 1;  // 変数 a を宣言している
        Debug.Log(a);

        string b = "1" + "1";
        Debug.Log(b);

        Debug.Log(a + b);   // この場合は暗黙的に a を文字列に変換する

        /*
            暗黙的な型変換ができずにエラーになることもあれば、暗黙的な型変換のために予期せぬ結果になることもある。
            型は常に意識しなければならない。
        */
    }

    void Update()
    {

    }
}
