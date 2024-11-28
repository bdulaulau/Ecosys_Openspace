using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 


public class Random_Movement : MonoBehaviour 
{
    public NavMeshAgent agent; //on peut assigner ainsi l'agent dans l'inspecteur
    public float range; //radius de la sph�re autour dans laquelle il va se balader

    public Transform centrePoint; //centre de la sph�re qui l'autorise � se d�placer dedans
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //va chercher un composant NavMeshAgent attach� � l'obj auquel ce scrip est attach�. Il deviendra alors agent
    }


    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) //v�rifie si l'agent a presque atteint sa destination, remainingDistance donne la distance restante avant que l'agent atteigne sa destination, et stoppingDistance est la distance o� il va se stopper
        {
            Vector3 point; //d�clare une variable type Vector3, utilis� pour stocker la position du point o� l'agent devra se rendre
            if (RandomPoint(centrePoint.position, range, out point)) //appelle la m�thode RandomPoint, qui g�n�re al�atoirement dans la sph�re autour du centre, si la m�thode trouve un point valide sur le NavMesh, elle retourne true et le point est stock� dans 'point'
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 2.0f); //permet d'afficher une ligne bleue dans l'�diteur pendant 2s
                agent.SetDestination(point); //demande � l'agent de se d�placer vers ce point
            }
        }

    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result) //g�n�re un point  dans une sph�re autour d'un centre donn�. Elle prend un center (centre de la sph�re), un range et renvoie un result (le point trouv�)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //g�n�re un point al�atoire dans une sph�re en utilisant Random.insideUnitSphere, qui donne un point al�atoire dans une sph�re de rayon 1. Ce point est multipli� ensuite par range pour ajuste la taille de la sph�re avec les param�trages rentr�s
        NavMeshHit hit; //d�clare hit de type NavMeshHit, qui sera utilis�e pour stocker des infos sur la point trouv� sur le NavMesh
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //V�rifie si le point randomPoint se trouve sur un NavMesh. NavMesh.SamplePosition essaie de trouver une position valide proche du randomPoint, si elle r�ussit elle retourne true
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;//si un point valide est trouv�, sa position est assign�e � la variable result
            return true;
        }

        result = Vector3.zero; //si aucun point valide n'a �t� trouv�, cette ligne assigne la position (0,0,0) � r�sult
        return false; // pour indiquer qu'aucun point valide n'a �t� trouv�
    }


}