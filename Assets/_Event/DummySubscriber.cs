using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ダミーのサブスクライバー
/// イベントハンドラとして登録している関数が何もないので、どんなイベントが raise してもただスキップされる
/// </summary>
public class DummySubscriber : MonoBehaviour
{
    private void OnDisable()
    {
        EventManager.Instance.Unsubscribe(this.gameObject);
    }

    void OnEnable()
    {
        EventManager.Instance.Subscribe(this.gameObject);
    }
}
