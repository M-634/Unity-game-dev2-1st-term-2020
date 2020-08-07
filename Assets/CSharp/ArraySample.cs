using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArraySample : MonoBehaviour
{
    void Start()
    {
        int[] intArray = { 9, 2, 3 };   // このように宣言 (declare) する

        Debug.Log("intArray の情報を出力する");
        Debug.LogFormat("intArray は {0} つの要素を含んでいます。", intArray.Length);
        Debug.Log(intArray[0]);
        Debug.Log(intArray[2]);
        Debug.Log(intArray[1]);

        float[] floatArray = new float[4];   // このように、要素数だけ決めて宣言することもできる

        Debug.Log("floatArray の情報を出力する");
        Debug.Log(floatArray[2]);   // その場合は既定値 (0.0) が入っている
        floatArray[3] = 2.5f;    // 後から値を入れることもできる
        Debug.Log(floatArray[3]);
    }

    void Update()
    {

    }
}
