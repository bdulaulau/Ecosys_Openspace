using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Bureau_Test : MonoBehaviour
{
    public float proximitydistance = 1;
    public Employee_Comportement employee_comportement;
    public GameObject Employee;
    private float timer = 0f;


    //void Update()
    //{
    //    Employee = GameObject.Find("Employee");
    //    float distance = Vector3.Distance(transform.position, Employee.transform.position);
    //    if (distance <= proximitydistance)
    //    {
    //        Debug.Log("Employ� pas loin !");
    //        timer += Time.deltaTime;
    //        if (timer >= 1f)
    //        {
    //            employee_comportement.TravailTest += 1;
    //            timer = 0f; //on r�initialise le timer
    //        }
    //    }

    //}
}
