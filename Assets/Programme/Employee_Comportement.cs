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

    public float proximitydistance_bureau = 1;
    public float proximitydistance_ressource = 1;

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

    private int Random;

    private void Start()
    {
        EnergyTest = MaxEnergyTest; //permet de définir au lancer la jauge à son maximum
        employee = GetComponent<NavMeshAgent>();
        bureau = GameObject.Find("bureau");
        ressource = GameObject.Find("test_ressource");
        employee.name = "Employee"; //changer de nom
    }


    private void Update()
    {  
        
        float distance_bureau = Vector3.Distance(bureau.transform.position, employee.transform.position);
        float distance_ressource = Vector3.Distance(ressource.transform.position, employee.transform.position);

        RechargeVerif();
        if (TravailTest == MaxTravailTest)
        {
            Destroy(employee.gameObject); //élimine l'employé dès qu'il a terminé sa jauge de travail
        }


        timer += Time.deltaTime;
        if (timer >= 1f) //permet de baisser de 1 toute les 1s la jauge
        {
            if (distance_bureau <= proximitydistance_bureau) //CODE BUREAU /!\
            {
                    TravailTest += 1;
            }
            EnergyTest -= 1;
            timer = 0f; //on réinitialise le timer
            Debug.Log("Random = " + Random);
            Debug.Log("L'énergie de " + employee + " est de " + EnergyTest);
        }
        if (distance_ressource <= proximitydistance_ressource) //CODE RESSOURCE /!\
        {
            Debug.Log("Employé pas loin !");
            EnergyTest = MaxEnergyTest; //recharge entierement sa jauge
        }
        if (EnergyTest <= RechargeEnergy)
        {
            employee.destination = ressource.transform.position;
        }
        else
        {
            employee.destination = bureau.transform.position;
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
