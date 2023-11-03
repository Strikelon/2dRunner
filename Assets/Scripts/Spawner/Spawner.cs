using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _prefab;
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
            if (TryGetObject(out GameObject result))
            {
                _elapsedTime = 0;
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetObject(result, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetObject(GameObject objectGame, Vector3 spawnPoint)
    {
        objectGame.SetActive(true);
        objectGame.transform.position = spawnPoint;
    }
}