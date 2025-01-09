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
    public GameObject Manager;
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

    //private int Random;

    private void Start()
    {
        EnergyTest = MaxEnergyTest; //permet de d�finir au lancer la jauge � son maximum
        employee = GetComponent<NavMeshAgent>();
        bureau = GameObject.Find("bureau");
        ressource = GameObject.Find("test_ressource");
        Manager = GameObject.Find("Manager");
        employee.name = "Employee"; //changer de nom
    }


    private void Update()
    {  
        
        float distance_bureau = Vector3.Distance(bureau.transform.position, employee.transform.position);//on r�cup�re la position du bureau
        float distance_ressource = Vector3.Distance(ressource.transform.position, employee.transform.position);//on r�cup�re la position du bloc "ressource"
        RechargeVerif(); 
        if (TravailTest == MaxTravailTest)
        {
            int randomNumber = UnityEngine.Random.Range(0, 101);//on g�n�re une chiffre entre 100
            Debug.Log("Proba" + randomNumber);
            if (randomNumber > 25)
                {
                Destroy(employee.gameObject); //�limine l'employ� d�s qu'il a termin� sa jauge de travail
                return;
            }
            else 
            {
                Instantiate(Manager);
                //Employee_Comportement script = Manager.GetComponent<Employee_Comportement>();
                Debug.Log("MANAGER HAS BEEN BORN");
                Destroy(employee.gameObject);
                return;
            }
        }

        timer += Time.deltaTime;
        if (timer >= 1f) //permet de baisser de 1 toute les 1s la jauge
        {
            if (distance_bureau <= proximitydistance_bureau) //CODE BUREAU /!\
            {
                    TravailTest += 1;
            }
            EnergyTest -= 1;
            timer = 0f; //on r�initialise le timer
            //Debug.Log("Random = " + Random);
            //Debug.Log("L'�nergie de " + employee + " est de " + EnergyTest);
        }
        if (distance_ressource <= proximitydistance_ressource) //CODE RESSOURCE /!\
        {
            Debug.Log("Employ� pas loin !");
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
        if (EnergyTest <= RechargeEnergy) //v�rifie si il est au stade o� il doit recharger sa jauge 
        {
            employee.destination = ressource.transform.position; //dirige l'employ� vers le lieu de recharge
            Debug.Log("L'�nergie de " + employee + " est de " + EnergyTest);
        }
    }

}
