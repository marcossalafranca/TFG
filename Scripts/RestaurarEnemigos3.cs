using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaurarEnemigos3 : MonoBehaviour{

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy21;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public GameObject enemy7;
    public GameObject enemy8;
    public GameObject enemy9;
    public GameObject enemy10;

    public GameObject vacio;

    public GameObject caja;
    public GameObject caja2;
    public GameObject caja3;
    public GameObject caja4;


    public GameObject muro;
    public GameObject basse;
    public GameObject muro2;
    public GameObject basse2;

    

    public GameObject palancaActivar;
    public GameObject palancaActivar2;


    public void Reactivar(){

        enemy1.SetActive(true);
        enemy2.SetActive(true);
        enemy21.SetActive(true);
        enemy3.GetComponent<CircleCollider2D>().enabled = false;
        enemy4.SetActive(true);
        enemy5.GetComponent<CircleCollider2D>().enabled = false;
        enemy6.SetActive(true);
        enemy7.SetActive(true);
        enemy8.SetActive(true);
        enemy9.SetActive(true);
        enemy10.SetActive(true);


        vacio.SetActive(true);

        caja.transform.position = new Vector3(13.14918f, -4.105f, 0);
        caja2.transform.position = new Vector3(77.34918f, -4.075f, 0);
        caja3.transform.position = new Vector3(94.49918f, -3.621f, 0);
        caja4.transform.position = new Vector3(127.9192f, -3.621f, 0);


        muro.transform.position = new Vector3(137.34f, 3.16f, 0);
        basse.SetActive(true);
        muro2.transform.position = new Vector3(175.12f, -2.87f, 0);
        basse2.SetActive(true);

   

        palancaActivar.GetComponent<Palanca>().abierto = false;
        palancaActivar2.GetComponent<Palanca>().abierto = false;
    }
    
   
}
