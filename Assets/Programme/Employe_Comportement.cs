using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]

public class Employe_Comportement : MonoBehaviour
{

    public Transform Target;

    private NavMeshAgent employee;
    
    public ressource_test ressource;  

    //Settings
    public int MaxEnergyTest = 100;
    public int EnergyTest;
    public int SpeedDrainEnergy = 3;
    private float timer = 0f; 


    private void Start()
    {
        EnergyTest = MaxEnergyTest;
       
        employee = GetComponent<NavMeshAgent>();
    }

     
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer>=1f)
        {
            EnergyTest -= 1;
            timer = 0f; //on réinitialise le timer
            Debug.Log("L'énergie de "+employee+" est de" + EnergyTest);
        }
        if (EnergyTest <= 95)
        {
            employee.destination = ressource.transform.position;
            Debug.Log("L'énergie de " + employee + " est de" + EnergyTest);
        }
        else
        {
            employee.destination = Target.position;
        }
    }

}
