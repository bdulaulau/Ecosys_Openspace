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
    //public int SpeedDrain = 3;
    private float timer = 0f;
    public int RechargeEnergy = 95;
    public int MaxTravailTest = 100;
    public int TravailTest;


    private void Start()
    {
        EnergyTest = MaxEnergyTest; //permet de d�finir au lancer la jauge � son maximum
       
        employee = GetComponent<NavMeshAgent>(); 
    }

     
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer>=1f) //permet de baisser de 1 toute les 1s la jauge
        {
            EnergyTest -= 1;
            timer = 0f; //on r�initialise le timer
            Debug.Log("L'�nergie de "+employee+" est de " + EnergyTest);
        }
        employee.destination = Target.position;
        if (EnergyTest <= RechargeEnergy) //v�rifie si il est au stade o� il doit recharger sa jauge 
        {
            employee.destination = ressource.transform.position; //dirige l'employ� vers le lieu de recharge
            Debug.Log("L'�nergie de " + employee + " est de " + EnergyTest);
        }

        if (TravailTest == MaxTravailTest)
        {
            Destroy(employee.gameObject);
        }

    }

}
