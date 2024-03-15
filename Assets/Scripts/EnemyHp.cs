using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private ParticleSystem[] _explosionThenHit;
    public void TakeDamage(float damage)
    {
        var i = Random.Range(1, 6);
        _explosionThenHit[i].Play();
        _health -= damage;
    }

    private void Update()
    {
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
