using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///イベントに登録するコンポーネントをまとめたGameオブジェクトにアタッチする
/// </summary>
public class EventsSubscriber : MonoBehaviour
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
