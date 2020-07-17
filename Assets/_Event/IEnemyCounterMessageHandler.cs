using UnityEngine.EventSystems;

public interface IEnemyCounterMessageHandler : IEventSystemHandler
{
    void OnEnemyDeath();
}
