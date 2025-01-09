using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Bureau_Test : MonoBehaviour
{
    public float proximitydistance = 1;
    public GameObject Employee;
    public GameObject bureau;
    private float distance; 

    private void Start()
    {
        Employee = GameObject.Find("Employee");
        bureau = GameObject.Find("zone de detection");
    }

    void Update()
    {
        distance = Vector3.Distance(bureau.transform.position, Employee.transform.position);
        if (distance <= proximitydistance)
        {
            Debug.Log("Employé pas loin !");
        }

    }
}
