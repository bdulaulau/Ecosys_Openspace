using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerSetting : MonoBehaviour
{
    private float _timer = 0f;
    public float _interval = 1f;
    public TMP_Text Chrono;
    

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
         if (_timer >= _interval)
        {
            _timer += 0.1f;

        }
        Chrono.text = _timer.ToString("00:00:00");



    }
}
