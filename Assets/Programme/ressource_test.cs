using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Ressource_test : MonoBehaviour
{
    public float proximitydistance = 1;
    public Employee_Comportement employee;
    public Manager_Comportement manager;
    private float distance_employee;
    private float distance_manager;

    void Update()
    {
        if (employee == null)
            return;
        if (manager == null)
            return;
        float distance_employee = Vector3.Distance(transform.position, employee.transform.position);
        float distance_manager = Vector3.Distance(transform.position, manager.transform.position);
        if (distance_employee <= proximitydistance)
        {
            Debug.Log("Employé pas loin !");
            employee.EnergyTest = employee.MaxEnergyTest; //recharge entierement sa jauge
        }
        if (distance_manager <= proximitydistance)
        {
            Debug.Log("Manager pas loin !");
            manager.EnergyTest = manager.MaxEnergyTest; //recharge entierement sa jauge
        }
    }
}