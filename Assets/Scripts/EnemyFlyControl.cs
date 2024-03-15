using UnityEngine;

public class EnemyFlyControl : MonoBehaviour
{
    [SerializeField] private Transform _airplane;
    [SerializeField] private float _flySpeed = 50;

    private void FixedUpdate()
    {
        _airplane.position += transform.forward * (_flySpeed * Time.deltaTime);
    }
}
