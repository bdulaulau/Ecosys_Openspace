using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeSpawn : MonoBehaviour
{
    public GameObject myEmployee;

    public void SpawnEmployee()
    {
        Instantiate(myEmployee);
        Employee_Comportement script = myEmployee.GetComponent<Employee_Comportement>();
    }


}
