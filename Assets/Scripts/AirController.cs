using System;
using MoreMountains.Feedbacks;
using UnityEngine;

public class AirController : MonoBehaviour
{
    [SerializeField] private VariableJoystick _joystick;
    
    [SerializeField] private Transform _airplane;
    [SerializeField] private AmmoSpawner _ammoSpawner;
    [SerializeField] private Transform[] _firePoint;
    [SerializeField] private Transform _referencePoint;
    [SerializeField] private float _flySpeed = 50;
    [SerializeField] private float _yawAround = 75;
    [SerializeField] private MMFeedbacks _mmFeedbacks;
    
    private float _yaw; 
    private float _targetPitch;
    private float _targetRoll;
    private float _pitchVelocity;
    private float _rollVelocity;
    private float _yawVelocity;

    private void FixedUpdate()
    {
        _airplane.position += transform.forward * (_flySpeed * Time.deltaTime);

        float horizontalInput = _joystick.Horizontal; 
        float verticalInput = _joystick.Vertical; 

        _yaw += horizontalInput * _yawAround * Time.deltaTime;
        
        _targetPitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        _targetRoll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);
        
        var pitch = Mathf.SmoothDampAngle(transform.eulerAngles.x, _targetPitch, ref _pitchVelocity, 0.1f);
        var roll = Mathf.SmoothDampAngle(transform.eulerAngles.z, _targetRoll, ref _rollVelocity, 0.1f);
        var yaw = Mathf.SmoothDampAngle(transform.eulerAngles.y, _yaw, ref _yawVelocity, 0.1f);
        
        transform.localRotation = Quaternion.Euler(new Vector3(pitch, yaw, roll));
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        foreach (var point in _firePoint)
        {
            _ammoSpawner.FireBullet(point.position, _referencePoint.position, point.rotation);
            _mmFeedbacks.PlayFeedbacks();
        }
    }
}