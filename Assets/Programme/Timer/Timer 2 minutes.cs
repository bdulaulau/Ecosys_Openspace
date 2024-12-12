using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class Timer2Setting : MonoBehaviour
{
    private float _timer = 0f; //Définit la variable _timer
    public float _interval = 120f; //Définit un interval pour la variable _time


    // Update is called once per frame
    void Update()
    {

        {
            _timer += Time.deltaTime; // Incrémente le temps écoulé chaque frame

            if (_timer >= _interval)
            {
                _timer = 0f; // Réinitialise le timer à zéro quand l'intervalle est atteint
                Debug.Log("Ça fait 2 minutes");
            }

        }
    }
}
       