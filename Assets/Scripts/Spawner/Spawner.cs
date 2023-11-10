using UnityEngine;

public class Spawner<T> : ObjectPool<T> where T : Component
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private T _prefab;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_prefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out T result))
            {
                _elapsedTime = 0;
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetObject(result, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetObject(T objectGame, Vector3 spawnPoint)
    {
        objectGame.gameObject.SetActive(true);
        objectGame.transform.position = spawnPoint;
    }
}