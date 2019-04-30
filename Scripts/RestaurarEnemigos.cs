using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaurarEnemigos : MonoBehaviour
{

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
    public GameObject vacio;
   



    public void Reactivar()
    {
        enemy1.SetActive(true);
        enemy2.SetActive(true);
        enemy21.GetComponent<CircleCollider2D>().enabled = false;
        enemy3.SetActive(true);
        enemy4.SetActive(true);
        enemy5.SetActive(true);
        enemy6.SetActive(true);
        enemy7.SetActive(true);
        enemy8.SetActive(true);
        enemy9.SetActive(true);
        vacio.SetActive(true);
        
    }
    
   
}
