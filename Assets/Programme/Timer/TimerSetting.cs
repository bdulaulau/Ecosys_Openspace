using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class TimerSetting : MonoBehaviour
{
    private float _timer = 0f; //Définit la variable _timer
    public float _interval = 1f; //Définit un interval pour la variable _timer
    public TMP_Text Chrono; //Permet d'afficher dans Unity


    // Update is called once per frame
    void Update()
    {

        _timer += Time.deltaTime; //le temps qui passe (frame transformer en seconde)
        if (_timer >= _interval)
        {
            _timer += 0; //Quand la variable _timer dépasse l'interval il se remet à 0
            TempsPassé(_timer); //Pour que le TempsPassé soit égal au nombre d'interval qui auront été passé
        }

    }

    void TempsPassé(float elapsed) 

    {
        int hours = (int)(elapsed / 3600); //Définit les heures
        int minutes = (int)((elapsed % 3600) / 60); //Définit les minutes
        int seconds = (int)(elapsed % 60); // Définit les secondes

        Chrono.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds); //Ecrire le texte au bon format en rappelant les valeurs du dessus

        Time.timeScale = 1; //définit le temps qui passe comme une valeur de base



        if (Input.GetKey(KeyCode.LeftArrow)) // actionner touche clavier gauche
            { 
            Time.timeScale = 0.5f; // Ralentis le temps en le divisant par 2
        }


        if (Input.GetKey(KeyCode.RightArrow)) // Actionner touche clavier droite
        { 
            Time.timeScale = 4; // Augmente le temps qui passe en le multipliant par 4
        }

        if(Input.GetKey(KeyCode.UpArrow))  // Actionner touche clavier haut
        {
            Time.timeScale = 10; // Augmente le temps qui passe en le multipliant par 10
        }

        if (Input.GetKey(KeyCode.DownArrow)) // Actionner touche clavier bas

        {
            Time.timeScale = 20; // Augmente le temps qui passe en le multipliant par 20
        }
    } }
