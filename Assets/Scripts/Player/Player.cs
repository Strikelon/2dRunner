using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private AudioSource _damageAudio;
    [SerializeField] private AudioSource _healthRecoveryAudio;

    private int _baseHealth;

    public UnityAction Died;
    public UnityAction<int> HealthChanged;
    public UnityAction<int> HealthInit;

    private void Start()
    {
        _baseHealth = _health;
        HealthInit?.Invoke(_baseHealth);
    }

    public void ApplyDamage(int damage)
    {
        _damageAudio.Play();
        _health -= damage;
        HealthChanged?.Invoke(_health);
        if (_health <= 0)
        {
            Die();
        }
    }

    public void ApplyHealthRecovery(int healthRecovery)
    {
        _healthRecoveryAudio.Play();
        if (_health + healthRecovery <= _baseHealth)
        {
            _health += healthRecovery;
            HealthChanged?.Invoke(_health);
        }
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
