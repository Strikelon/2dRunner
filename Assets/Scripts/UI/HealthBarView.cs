using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Heart _heartPrefab;
    [SerializeField] private Player _player;
    [SerializeField] private int _heartsXPositionStep;

    private List<Heart> _hearts = new List<Heart>();
    private Vector3 _currentHeartPosition;

    private void Start()
    {
        _currentHeartPosition = transform.position;
    }

    private void OnEnable()
    {
        _player.HealthInit += OnHealthInit;
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
        _player.HealthInit -= OnHealthInit;
    }

    private void OnHealthChanged(int health)
    {
        for (int i = 0; i< _hearts.Count;i++)
        {
            if (i < health)
            {
                _hearts[i].ToFill();
            }
            else
            {
                _hearts[i].ToEmpty();
            }
        }
    }

    private void OnHealthInit(int baseHealth)
    {
        for (int i = 0; i < baseHealth; i++)
        {
            Heart heart = Instantiate(_heartPrefab, transform);
            heart.transform.localPosition = _currentHeartPosition;
            heart.ToFill();
            _hearts.Add(heart);
            _currentHeartPosition += new Vector3(_heartsXPositionStep, 0f, 0f);
        }
    }
}
