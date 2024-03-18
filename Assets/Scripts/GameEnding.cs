using System;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [SerializeField] private AirPlane _enemy;
    [SerializeField] private AirPlane _player;
    [SerializeField] private GameObject _canvas;
    
    private EnemyHp _enemyHp;
    
    private float _playerPosZ;
    private float _enemyPosZ;
    

    private void Start()
    {
        _enemyHp = _enemy.GetComponent<EnemyHp>();
        _playerPosZ = _player.transform.position.z;
        _enemyPosZ = _enemy.transform.position.z;
    }

    private void Update()
    {
        _playerPosZ = _player.transform.position.z;
        
        if (_enemyHp)
        {
            _enemyPosZ = Mathf.Infinity;
        }
       
        if (_enemy != null && !_enemyHp.IsDead)
        {
            _enemyPosZ = _enemy.transform.position.z;
        }

        if (_playerPosZ >= _enemyPosZ || _enemy == null)
        {
            End();
        }
    }

    private void End()
    {
        _canvas.SetActive(true);
        var allAudioSources = FindObjectsOfType<AudioSource>();
        
        foreach (var audioS in allAudioSources)
        {
            audioS.Pause(); 
        }
    }
}
