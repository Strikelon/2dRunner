using UnityEngine;
using UnityEngine.Events;

public class Destroyer : MonoBehaviour
{
    public UnityAction<int> EnemyDestroyed;

    private void Start()
    {
        EnemyDestroyed?.Invoke(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        { 
            EnemyDestroyed?.Invoke(enemy.Score);
            enemy.Die();
        }
    }
}
