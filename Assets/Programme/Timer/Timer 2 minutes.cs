using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class Timer2Setting : MonoBehaviour
{
    private float _timer = 0f; //D�finit la variable _timer
    public float _interval = 120f; //D�finit un interval pour la variable _time


    // Update is called once per frame
    void Update()
    {

        {
            _timer += Time.deltaTime; // Incr�mente le temps �coul� chaque frame

            if (_timer >= _interval)
            {
                _timer = 0f; // R�initialise le timer � z�ro quand l'intervalle est atteint
                Debug.Log("�a fait 2 minutes");
            }

        }
    }
}
       