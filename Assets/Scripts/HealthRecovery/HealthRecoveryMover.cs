using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRecoveryMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
