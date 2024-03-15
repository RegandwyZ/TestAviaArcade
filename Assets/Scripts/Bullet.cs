using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bullet: MonoBehaviour
    {
        public event Action<Bullet> OnBulletReturnRequested;
        
        private Rigidbody _rigidbody;
        
        [SerializeField] private float _force = 100f;
        [SerializeField] private float _damage;
        [SerializeField] private ParticleSystem _particle;
        
        private const float _lifetime = 0.8f;
        private float _timeSinceActivated;
        private bool _isMoving;
       

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        private void OnEnable()
        {
            _timeSinceActivated = 0; 
        }
        public void Activate(Vector3 targetPosition)
        {
            _rigidbody.velocity = Vector3.zero; 
            var direction = (targetPosition - transform.position).normalized; 
            _rigidbody.AddForce(direction * _force); 
        }

        private void Deactivate()
        {
            _rigidbody.velocity = Vector3.zero;
            OnBulletReturnRequested?.Invoke(this);
        }
        
        private void Update()
        {
            _timeSinceActivated += Time.deltaTime;
            if (_timeSinceActivated >= _lifetime)
            {
                  Deactivate();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            var enemyHp = collision.gameObject.GetComponent<EnemyHp>();
            if (enemyHp != null)
            {
                enemyHp.TakeDamage(_damage);
                _particle.Play();
              //  Deactivate();
            }
        }
    }
}