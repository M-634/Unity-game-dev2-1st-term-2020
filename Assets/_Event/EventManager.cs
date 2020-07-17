using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// イベントを管理する。購読者を登録・登録解除する。イベントを raise する。
/// </summary>
public class EventManager : SingletonMonoBehaviour<EventManager>
{
    /// <summary>イベント購読者リスト</summary>
    List<GameObject> m_subscriberList  = new List<GameObject>();

    /// <summary>
    /// イベントを購読する
    /// </summary>
    /// <param name="go">イベント購読者として登録するオブジェクト</param>
    public void Subscribe(GameObject go)
    {
        Debug.Log(go.name + " is registered as subscriber.");
        m_subscriberList.Add(go);
    }

    /// <summary>
    /// イベント購読を解除する
    /// </summary>
    /// <param name="go">イベント購読の登録を解除するオブジェクト</param>
    public void Unsubscribe(GameObject go)
    {
        Debug.Log(go.name + " unsubscribed.");
        m_subscriberList.Remove(go);
    }

    /// <summary>
    /// 登録された GameObject から、コンポーネント T の関数 functor を呼び出す
    /// コンポーネント T は IEventSystemHandler を継承したインターフェイスを実装していなければならない
    /// 登録された GameObject がコンポーネント T を持っていなければ、そのオブジェクトに対しては何もしない
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <param name="functor"></param>
    public void RaiseEvent<T>(BaseEventData data, ExecuteEvents.EventFunction<T> functor) where T: IEventSystemHandler
    {
        Debug.Log("Event raised.");
        GameObject[] subscribers = m_subscriberList.ToArray();  // 実行中に List から要素が削除されてエラーになるため、配列にコピーして使う

        // 全ての Subscriber に対してイベントとして指定された関数を呼び出す
        foreach (var go in subscribers)
        {
            Debug.Log("Try execute on " + go.name);

            bool result = ExecuteEvents.Execute<T>(go, null, functor);
            if (result)
            {
                Debug.Log("Success for " + go.name);
            }
            else
            {
                Debug.Log(go.name + " doesn't have the event specified. Do nothing.");
            }
        }
    }
}
