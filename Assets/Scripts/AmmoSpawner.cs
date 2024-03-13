using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
   [SerializeField] private Bullet _bulletPrefab;
   private AmmoPool<Bullet> _bulletPool;

   private void Start()
   {
      _bulletPool = new AmmoPool<Bullet>(_bulletPrefab, 10);
   }

   public void FireBullet(Vector3 position, Vector3 target, Quaternion pointRotation)
   {
      var bullet = _bulletPool.Get();
      bullet.transform.position = position;
      bullet.transform.rotation = pointRotation;
      bullet.Activate(target);
      bullet.OnBulletReturnRequested += ReturnBulletToPool;
   }

   private void ReturnBulletToPool(Bullet bullet)
   {
      bullet.OnBulletReturnRequested -= ReturnBulletToPool;
      _bulletPool.Release(bullet);
   }
   
}
