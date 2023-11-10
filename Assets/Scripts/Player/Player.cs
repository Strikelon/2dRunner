using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private AudioSource _damageAudio;
    [SerializeField] private AudioSource _healthRecoveryAudio;

    private int _baseHealth;
    private int _minHealth = 0;

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
        _health = Mathf.Clamp(_health - damage, _minHealth, _baseHealth);
        HealthChanged?.Invoke(_health);
        if (_health <= _minHealth)
        {
            Die();
        }
    }

    public void ApplyHealthRecovery(int healthRecovery)
    {
        _healthRecoveryAudio.Play();
        _health = Mathf.Clamp(_health + healthRecovery, _minHealth, _baseHealth);
        HealthChanged?.Invoke(_health);
    }

    public void Die()
    {
        Died?.Invoke();
    }
}