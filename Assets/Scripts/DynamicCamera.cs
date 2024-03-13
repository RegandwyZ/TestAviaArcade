using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    [SerializeField] private Transform _cameraPoint; 
    [SerializeField] private  Vector3 _offset = new Vector3(0, 5, -10);
    public float followSpeed = 5f; 
    public float rotationSpeed = 5f;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        var targetPosition = _cameraPoint.position + _cameraPoint.TransformDirection(_offset);
        
        transform.position =
            Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, followSpeed * Time.deltaTime);
        
        var targetRotation = Quaternion.LookRotation(_cameraPoint.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}