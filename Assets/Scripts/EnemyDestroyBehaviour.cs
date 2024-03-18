using System;
using UnityEngine;


public class EnemyDestroyBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fireEffect;
    [SerializeField] private float _diveSpeed = 25f;
    [SerializeField] private float _rotationSpeed = 50f;

    public bool _isDying;

    public void StartDyingSequence()
    {
        _isDying = true;
        _fireEffect.Play();
    }

    private void FixedUpdate()
    {
        if (!_isDying) return;
        transform.Translate(Vector3.down * (_diveSpeed * Time.deltaTime), Space.World);
        transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
        Invoke(nameof(Die), 5f); 
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }
}

