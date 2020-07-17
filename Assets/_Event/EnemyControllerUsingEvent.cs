using UnityEngine;

/// <summary>
/// 敵を制御するコンポーネント。
/// イベント購読者として自分自身を登録する。Die 関数はイベントハンドラ関数となっているので、EventManager からイベントとしても呼ばれる。
/// </summary>
public class EnemyControllerUsingEvent : MonoBehaviour, IEnemyMessageHandler
{
    /// <summary>消える時に出すエフェクト</summary>
    [SerializeField] GameObject m_explosionEffect;
    private bool m_isDead;

    public bool IsDead
    {
        get { return this.m_isDead; }
    }

    private void OnDisable()
    {
        EventManager.Instance.Unsubscribe(this.gameObject);
    }

    void OnEnable()
    {
        EventManager.Instance.Subscribe(this.gameObject);
    }

    public void Die()
    {
        m_isDead = true;
        EventManager.Instance.RaiseEvent<EnemyCounterUsingEvent>(null, (x, y) => x.OnEnemyDeath());
        Instantiate(m_explosionEffect, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletTag"))
        {
            Die();
        }
    }
}
