using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Compteur_unité : MonoBehaviour
   {
    //public int nmbmanager = 0; A METTRE  A JOUR
    public int nmbdemployé = 0;
    public TMP_Text compteurtext;


    // Start is called before the first frame update
    void Start()
    {
        
        
     }

    // Update is called once per frame
    void Update()
    {
        int nmbdemployé = GameObject.FindObjectsOfType<Employee_Comportement>().Length;

        //int nmbmanager = GameObject.FindObjectOfType<Manager_Comportement>().Length; //A METTRE A JOUR POUR LES MANAGER

        compteurtext.text = nmbdemployé + " employés";
        //compteurtext.text =   DEUXIEME LIGNE DE TEXTE "MANAGER"
     
    }
}
