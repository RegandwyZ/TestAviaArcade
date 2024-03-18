using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private ParticleSystem[] _explosionThenHit;
    [SerializeField] private EnemyDestroyBehaviour _destroyBehaviour;
    
    private bool _isDestroy;
    public bool IsDead;
    public void TakeDamage(float damage)
    {
        var i = Random.Range(0, _explosionThenHit.Length);
        _explosionThenHit[i].Play();
        _health -= damage;
    }

    private void Update()
    {
        if (_health <= 0 && !_isDestroy)
        {
            _destroyBehaviour.StartDyingSequence();
            _isDestroy = false;
            IsDead = true;
        }
    }
}
