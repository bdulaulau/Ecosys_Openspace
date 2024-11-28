using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]

public class Employee_Comportement : MonoBehaviour
{

    public Transform Target;

    private NavMeshAgent employee;
    
    public Ressource_test ressource;  

    //Settings
    public int MaxEnergyTest = 100;
    public int EnergyTest;

    private float timer = 0f;
    public int RechargeEnergy = 95;

    public int MaxTravailTest = 100;
    public int TravailTest;

    public int MaxStress = 50;
    public int Stress;

    private int Random;

    private void Start()
    {
        EnergyTest = MaxEnergyTest; //permet de définir au lancer la jauge à son maximum
       
        employee = GetComponent<NavMeshAgent>(); 
    }

     
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer>=1f) //permet de baisser de 1 toute les 1s la jauge
        {
            EnergyTest -= 1;
            timer = 0f; //on réinitialise le timer
            Debug.Log("Random = " + Random);
            Debug.Log("L'énergie de "+employee+" est de " + EnergyTest);
        }
        employee.destination = Target.position; //va travailler
        RechargeVerif();
        if (TravailTest == MaxTravailTest)
        {
            Destroy(employee.gameObject); //élimine l'employé dès qu'il a terminé sa jauge de travail
        }

    }

    public void RechargeVerif()
    {
        if (EnergyTest <= RechargeEnergy) //vérifie si il est au stade où il doit recharger sa jauge 
        {
            employee.destination = ressource.transform.position; //dirige l'employé vers le lieu de recharge
            Debug.Log("L'énergie de " + employee + " est de " + EnergyTest);
        }
    }


}
