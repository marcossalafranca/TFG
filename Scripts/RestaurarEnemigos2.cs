using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaurarEnemigos2 : MonoBehaviour{

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

    public GameObject enemy11;
    public GameObject enemy12;
    public GameObject enemy13;
    public GameObject enemy14;
    public GameObject enemy15;
    public GameObject enemy16;
    public GameObject enemy17;
    public GameObject enemy18;

    public GameObject vacio;
    public GameObject caja;
    public GameObject caja2;
    public GameObject caja3;
    public GameObject caja4;
    public GameObject caja5;
    public GameObject caja6;
    public GameObject caja7;
    public GameObject caja8;

    public GameObject muro;
    public GameObject basse;

   

    public GameObject palancaActivar;


    public void Reactivar(){

        enemy1.SetActive(true);
        enemy2.SetActive(true);
        enemy21.SetActive(true);
        enemy3.GetComponent<CircleCollider2D>().enabled = false;
        enemy4.SetActive(true);
        enemy5.GetComponent<CircleCollider2D>().enabled = false;
        enemy6.SetActive(true);
        enemy7.SetActive(true);
        enemy8.GetComponent<CircleCollider2D>().enabled = false;
        enemy9.SetActive(true);
        enemy10.GetComponent<CircleCollider2D>().enabled = false;
        enemy11.SetActive(true);
        enemy12.SetActive(true);
        enemy13.SetActive(true);
        enemy14.SetActive(true);
        enemy15.SetActive(true);
        enemy16.SetActive(true);

        enemy17.SetActive(true);
        enemy18.GetComponent<CircleCollider2D>().enabled = false;


        vacio.SetActive(true);

        caja.transform.position = new Vector3(181.3792f, -4.044439f, 0);
        caja2.transform.position = new Vector3(157.05f, -3.994439f, 0);
        caja3.transform.position = new Vector3(181.39f, -3.414439f, 0);
        caja4.transform.position = new Vector3(172.71f, -4.034439f, 0);
        caja5.transform.position = new Vector3(186.4f, -4.024439f, 0);
        caja6.transform.position = new Vector3(183.77f, -2.024439f, 0);
        caja7.transform.position = new Vector3(185.65f, -0.3444394f, 0);
        caja8.transform.position = new Vector3(76.25634f, -3.980325f, 0);




        muro.transform.position = new Vector3(119.2933f, -3.454492f, 0);
        basse.SetActive(true);


        palancaActivar.GetComponent<Palanca>().abierto = false;
    }
    
   
}
