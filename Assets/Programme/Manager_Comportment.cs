using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Manager_Comportement : MonoBehaviour
{
    public GameObject Employee;
    public GameObject bureau;

    public NavMeshAgent Manager;

    public float proximitydistance_bureau = 1;
    public float proximitydistance_ressource = 1;

    public GameObject ressource;

    //Settings
    public int MaxEnergyTest = 100;
    public int EnergyTest;

    private float timer = 0f;
    public int RechargeEnergy = 95;

    public int MaxTravailTest = 100;
    public int TravailTest;

    //public int MaxStress = 50;
    //public int Stress;

    private void Start()
    {
        EnergyTest = MaxEnergyTest; //permet de définir au lancer la jauge à son maximum
        Manager = GetComponent<NavMeshAgent>();
        bureau = GameObject.Find("bureau");
        ressource = GameObject.Find("test_ressource");
        Manager.name = "Manager"; //changer de nom
    }


    private void Update()
    {

        float distance_bureau = Vector3.Distance(bureau.transform.position, Manager.transform.position);
        float distance_ressource = Vector3.Distance(ressource.transform.position, Manager.transform.position);


        timer += Time.deltaTime;
        if (timer >= 1f) //permet de baisser de 1 toute les 1s la jauge
        {
            if (distance_bureau <= proximitydistance_bureau) //CODE BUREAU /!\
            {
                TravailTest += 1;
            }
            EnergyTest -= 1;
            timer = 0f; //on réinitialise le timer
            Debug.Log("L'énergie de " + Manager + " est de " + EnergyTest);
        }
        if (distance_ressource <= proximitydistance_ressource) //CODE RESSOURCE /!\
        {
            Debug.Log("Manager pas loin !");
            EnergyTest = MaxEnergyTest; //recharge entierement sa jauge
        }
        if (EnergyTest <= RechargeEnergy)
        {
            Manager.destination = ressource.transform.position;
        }
        else
        {
            Manager.destination = bureau.transform.position;
        }

        RechargeVerif();
        if (timer >= 600f)
        {
            Destroy(Manager.gameObject); //élimine l'employé dès qu'il a terminé sa jauge de travail
        }
        //à configurer avec le timer 2 minutes 
        {
            int randomValue = Random.Range(1, 101);
            if (randomValue <= 25)
            {
                Instantiate(Employee, Employee.transform);
            }
        }
    }

    public void RechargeVerif()
    {
        if (EnergyTest <= RechargeEnergy) //vérifie si il est au stade où il doit recharger sa jauge 
        {
            Manager.destination = ressource.transform.position; //dirige l'employé vers le lieu de recharge
            Debug.Log("L'énergie de " + Manager + " est de " + EnergyTest);
        }
    }


}
