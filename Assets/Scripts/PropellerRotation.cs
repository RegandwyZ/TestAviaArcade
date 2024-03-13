using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRotation : MonoBehaviour
{
   [SerializeField] private Transform _propeller;
   [SerializeField] private float _rotationSpeed;
   
   private void Update()
   {
      _propeller.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
   }
}
