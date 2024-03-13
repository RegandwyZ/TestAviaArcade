using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AmmoPool<T> where T : MonoBehaviour
{
   private readonly T _ammoPrefab;
   private readonly List<T> _objects;
   
   public AmmoPool(T prefab, int prewarmObjects)
   {
      _ammoPrefab = prefab;
      _objects = new List<T>();

      for (int  i = 0; i < prewarmObjects; i++)
      {
         var obj = Object.Instantiate(_ammoPrefab);
         obj.gameObject.SetActive(false);
         _objects.Add(obj);
      }
   }

   public T Get()
   {
      var bullet = _objects.FirstOrDefault(x => !x.isActiveAndEnabled);

      if (bullet == null)
      {
         bullet = Create();
      }

      bullet.gameObject.SetActive(true);
      return bullet;
   }

   public void Release(T bullet)
   {
      bullet.gameObject.SetActive(false);
   }

   private T Create()
   {
      var bullet = Object.Instantiate(_ammoPrefab);
      _objects.Add(bullet);
      return bullet;
   }
}

