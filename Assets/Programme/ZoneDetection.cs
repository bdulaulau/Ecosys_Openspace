using UnityEngine;

public class ZoneDetection : MonoBehaviour
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
        Debug.Log("Bureau: " + bureau);
        Debug.Log("Employee: " + Employee);
        distance = Vector3.Distance(bureau.transform.position, Employee.transform.position);
        if (distance <= proximitydistance)
        {
            Debug.Log("Employé pas loin !");
        }
    }
}
