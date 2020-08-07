using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFlow : MonoBehaviour
{
    void Start()
    {
        bool isPrime;   // 素数 (prime number) かどうかの判定結果を入れておく変数

        Debug.Log("20 未満の素数を出力する");

        for (int i = 2; i < 20; i++)    // i を 2, 3, 4, ..., 17, 18, 19 と変えて繰り返し処理する
        {
            Debug.LogFormat("{0} が素数かどうか判定する", i);
            isPrime = true; // 最初は素数とみなす

            // i を 2, 3, 4, ... , i - 1 で順番に割っていく
            for (int j = 2; j < i; j++) // カウンタ変数は
            {
                if (i % j == 0) // i が自分より小さい整数で割り切れたらもう素数ではない。なお % は剰余を計算する演算子である。
                {
                    Debug.LogFormat("{0} は {1} で割り切れる。素数ではない。", i, j);
                    isPrime = false;    // 素数ではないと判定で来た
                    break;  // もう素数ではないのでこれ以上計算する必要はない。ループを抜ける。
                }
            }
            
            if (isPrime)
            {
                Debug.LogFormat("{0} は素数である。", i);
            }
        }

        Debug.Log("20 未満の奇数を出力する");

        for (int i = 1; i < 20; i++)
        {
            // 練習のコードをここに追記せよ
            // Debug.LogFormat("{0} は奇数である。",　i);
        }
    }

    void Update()
    {

    }
}
