using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Ressource_test : MonoBehaviour
{
    public float proximitydistance = 1;
    public Employee_Comportement employe;     

    void Update()
    {
        float distance = Vector3.Distance(transform.position, employe.transform.position);
        if (distance <= proximitydistance)
        {
            Debug.Log("Employé pas loin !");
            employe.EnergyTest = employe.MaxEnergyTest; //recharge entierement sa jauge
        }
    }
}