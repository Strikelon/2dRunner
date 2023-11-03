using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _score;

    public int Score => _score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
