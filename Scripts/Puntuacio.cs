using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacio: MonoBehaviour{

    GameManager gm;
    public GameObject pie;

     void Awake(){

        gm = FindObjectOfType<GameManager>();

    }

    private void OnTriggerEnter2D(Collider2D other){

       if (other.gameObject.tag == "Moneda"){

            gm.ActualizarMonedas();
            gm.ActualizarPuntos(100);
            Destroy(other.gameObject);

        }

        if (other.gameObject.tag == "Cereza") {

            gm.ActualizarVidas();
            gm.ActualizarPuntos(300);
            Destroy(other.gameObject);

        }

        if(other.gameObject.tag == "Rubi" ) {
   
            gm.ActualizarRubi();
            gm.ActualizarPuntos(500);
            Destroy(other.gameObject);

        }
     
    }





}