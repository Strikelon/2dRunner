using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<T> _pool = new List<T>();

    protected void Initialize(T prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            T spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out T result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}