using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 


public class Random_Movement : MonoBehaviour 
{
    public NavMeshAgent agent; //on peut assigner ainsi l'agent dans l'inspecteur
    public float range; //radius de la sphère autour dans laquelle il va se balader

    public Transform centrePoint; //centre de la sphère qui l'autorise à se déplacer dedans
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //va chercher un composant NavMeshAgent attaché à l'obj auquel ce scrip est attaché. Il deviendra alors agent
    }


    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) //vérifie si l'agent a presque atteint sa destination, remainingDistance donne la distance restante avant que l'agent atteigne sa destination, et stoppingDistance est la distance où il va se stopper
        {
            Vector3 point; //déclare une variable type Vector3, utilisé pour stocker la position du point où l'agent devra se rendre
            if (RandomPoint(centrePoint.position, range, out point)) //appelle la méthode RandomPoint, qui génère aléatoirement dans la sphère autour du centre, si la méthode trouve un point valide sur le NavMesh, elle retourne true et le point est stocké dans 'point'
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 2.0f); //permet d'afficher une ligne bleue dans l'éditeur pendant 2s
                agent.SetDestination(point); //demande à l'agent de se déplacer vers ce point
            }
        }

    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result) //génère un point  dans une sphère autour d'un centre donné. Elle prend un center (centre de la sphère), un range et renvoie un result (le point trouvé)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //génère un point aléatoire dans une sphère en utilisant Random.insideUnitSphere, qui donne un point aléatoire dans une sphère de rayon 1. Ce point est multiplié ensuite par range pour ajuste la taille de la sphère avec les paramétrages rentrés
        NavMeshHit hit; //déclare hit de type NavMeshHit, qui sera utilisée pour stocker des infos sur la point trouvé sur le NavMesh
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //Vérifie si le point randomPoint se trouve sur un NavMesh. NavMesh.SamplePosition essaie de trouver une position valide proche du randomPoint, si elle réussit elle retourne true
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;//si un point valide est trouvé, sa position est assignée à la variable result
            return true;
        }

        result = Vector3.zero; //si aucun point valide n'a été trouvé, cette ligne assigne la position (0,0,0) à résult
        return false; // pour indiquer qu'aucun point valide n'a été trouvé
    }


}