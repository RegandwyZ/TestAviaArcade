using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float slowMotionFactor = 0.5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SlowMotion();
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            NormalTime();
        }
    }

    private void SlowMotion()
    {
        Time.timeScale = slowMotionFactor;
        Time.fixedDeltaTime = 0.02f * Time.timeScale; 
    }

    private void NormalTime()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f; 
    }
}
