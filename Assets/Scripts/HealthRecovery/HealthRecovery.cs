using UnityEngine;

public class HealthRecovery : MonoBehaviour
{
    [SerializeField] private int _healthRecovery;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyHealthRecovery(_healthRecovery);
        }

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
