using UnityEngine;

public class AirPlaneController : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed; 
    [SerializeField] private float _tiltSpeed;
    [SerializeField] private float _turnSpeed;

    private void Update()
    {
      
        transform.Translate(Vector3.forward * (_forwardSpeed * Time.deltaTime));

        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right, -_tiltSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.right, _tiltSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, _turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, -_turnSpeed * Time.deltaTime);
        }
    }
}
