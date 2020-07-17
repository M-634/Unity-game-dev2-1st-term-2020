using UnityEngine;

/// <summary>
/// 爆弾を制御するコンポーネント。これを撃つと、イベント登録した EnemyControllerUsingEvent コンポーネントを持ったオブジェクト全てに対して Die 関数を呼んで破壊する。
/// </summary>
public class BombController : MonoBehaviour
{
    [SerializeField] GameObject m_explosionEffect;

    void Bomb()
    {
        Instantiate(m_explosionEffect, this.transform.position, Quaternion.identity);
        EventManager.Instance.RaiseEvent<EnemyControllerUsingEvent>(null, (x, y) => x.Die());
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletTag")
        {
            Bomb();
        }
    }
}
