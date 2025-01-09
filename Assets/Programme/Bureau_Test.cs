using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Bureau_Test : MonoBehaviour
{
    public float proximitydistance = 1;
    public GameObject Employee;
    public GameObject Manager;
    public GameObject bureau;
    private float distance_e;
    private float distance_m;

    private void Start()
    {
        Employee = GameObject.Find("Employee");
        bureau = GameObject.Find("bureau");
        Manager = GameObject.Find("Manager");
    }

    void Update()
    {
        if (Employee== null)
            return;
        if (Manager == null)
            return;
        float distance_float_employee = Vector3.Distance(bureau.transform.position, Employee.transform.position);
        float distance_float_manager = Vector3.Distance(bureau.transform.position, Employee.transform.position);
        distance_e = distance_float_employee;
        distance_m = distance_float_manager;
        if (distance_e <= proximitydistance)
        {
            Debug.Log("Employé pas loin !");
        }
        if (distance_m <= proximitydistance)
        {
            Debug.Log("Manager pas loin !");
        }

    }
}
