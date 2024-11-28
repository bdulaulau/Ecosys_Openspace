using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bureau_Test : MonoBehaviour
{
    public float proximitydistance = 1;
    public Employee_Comportement employe;
    private float timer = 0f;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, employe.transform.position);
        if (distance <= proximitydistance)
        {
            Debug.Log("Employé pas loin !");
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                employe.TravailTest += 1;
                timer = 0f; //on réinitialise le timer
            }
        }

    }
}
