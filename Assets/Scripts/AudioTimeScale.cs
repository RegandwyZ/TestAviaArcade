using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTimeScale : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_audioSource == null) return;
        _audioSource.pitch = Time.timeScale;
    }
}
