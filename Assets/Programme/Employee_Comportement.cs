using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;


[RequireComponent(typeof(NavMeshAgent))]

public class Employee_Comportement : MonoBehaviour
{

    public GameObject bureau;

    public NavMeshAgent employee;
    
    public GameObject ressource;  

    //Settings
    public int MaxEnergyTest = 100;
    public int EnergyTest;

    private float timer = 0f;
    public int RechargeEnergy = 95;

    public int MaxTravailTest = 100;
    public int TravailTest;

    //public int MaxStress = 50;
    //public int Stress;

    //private int Random;

    private void Start()
    {
        EnergyTest = MaxEnergyTest; //permet de d�finir au lancer la jauge � son maximum
        employee = GetComponent<NavMeshAgent>();
        Target = GameObject.Find("bureau");
        ressource = GameObject.Find("test_ressource");
        employee.name = "Employee"; //changer de nom
    }

     
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer>=1f) //permet de baisser de 1 toute les 1s la jauge
        {
            EnergyTest -= 1;
            timer = 0f; //on r�initialise le timer
            //Debug.Log("Random = " + Random);
            Debug.Log("L'�nergie de "+employee+" est de " + EnergyTest);
        }
        employee.destination = bureau.transform.position; //va travailler
        RechargeVerif();
        if (TravailTest == MaxTravailTest)
        {
            Destroy(employee.gameObject); //�limine l'employ� d�s qu'il a termin� sa jauge de travail
        }

    }

    public void RechargeVerif()
    {
        if (EnergyTest <= RechargeEnergy) //v�rifie si il est au stade o� il doit recharger sa jauge 
        {
            employee.destination = ressource.transform.position; //dirige l'employ� vers le lieu de recharge
            Debug.Log("L'�nergie de " + employee + " est de " + EnergyTest);
        }
    }


}
