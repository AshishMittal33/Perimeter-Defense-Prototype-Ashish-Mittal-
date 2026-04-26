using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    private Spawner spawner;

    public void Init(Spawner sp)
    {
        spawner = sp;
    }

    void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.OnEnemyDestroyed();
        }
    }
}