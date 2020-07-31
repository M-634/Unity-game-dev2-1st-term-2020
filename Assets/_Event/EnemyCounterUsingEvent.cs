using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyCounterUsingEvent : MonoBehaviour, IEnemyCounterMessageHandler
{
    bool m_isAllEnemiesCleared;

    //private void OnDisable()
    //{
    //    EventManager.Instance.Unsubscribe(this.gameObject);
    //}


    //void OnEnable()
    //{
    //    EventManager.Instance.Subscribe(this.gameObject);
    //}

    public void OnEnemyDeath()
    {
        // 敵が死んだという通知を受け取ったら、残っている敵の数を数える
        Debug.Log("Received OnEnemyDeath notification.");
        StartCoroutine(CountEnemies());
    }

    IEnumerator CountEnemies()
    {
        // 爆弾で敵を一気にやっつけた時は重いのでウェイトを入れている
        yield return new WaitForFixedUpdate();
        EnemyControllerUsingEvent[] enemies = GameObject.FindObjectsOfType<EnemyControllerUsingEvent>();
        yield return new WaitForFixedUpdate();
        int enemyCount = enemies.ToList().Where(x => x.IsDead == false).Count();
        Debug.Log("Enemies remaining: " + enemyCount);
        yield return new WaitForFixedUpdate();

        if (!m_isAllEnemiesCleared && enemyCount == 0)
        {
            m_isAllEnemiesCleared = true;
            Debug.LogWarning("All enemies cleared.");
        }
    }
}
