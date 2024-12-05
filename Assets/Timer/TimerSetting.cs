using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

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
            _timer += 0;
            TempsPassé(_timer);
        }

    }

    void TempsPassé(float elapsed)

    {
        int hours = (int)(elapsed / 3600);
        int minutes = (int)((elapsed % 3600) / 60);
        int seconds = (int)(elapsed % 60);

        Chrono.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);

        Time.timeScale = 1;



        if (Input.GetKey(KeyCode.LeftArrow))
            { 
            Time.timeScale = 0.5f;
        }


        if (Input.GetKey(KeyCode.RightArrow))
        { 
            Time.timeScale = 4;
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            Time.timeScale = 10;
        }

        if (Input.GetKey(KeyCode.DownArrow))

        {
            Time.timeScale = 20;
        }
    } }
