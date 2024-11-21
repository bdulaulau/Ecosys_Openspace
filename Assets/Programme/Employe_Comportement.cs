using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]

public class Employe_Comportement : MonoBehaviour
{

    public Transform Target;

    private NavMeshAgent _agent;

    public int MaxEnergyTest = 100;

    public int EnergyTest;

    public int SpeedDrainEnergy = 3;



    public 
    private void Start()
    {
        EnergyTest = MaxEnergyTest;
       
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = Target.position;
    }

     
    private void Update()
    {
        EnergyTest -= 1;
        if (EnergyTest <= 90) ;
        _agent.destination = Target.position;
    }

}
