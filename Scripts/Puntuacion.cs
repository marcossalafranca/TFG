using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion: MonoBehaviour{

    GameManager gm;

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

        if(other.gameObject.tag == "Rubi") {
            //Debug.Log("toca");
            gm.ActualizarRubi();
            gm.ActualizarPuntos(500);
            Destroy(other.gameObject);

        }
      /*  if (other.gameObject.tag == "enemigo")
        {
           Debug.Log("toca");
            gm.ActualizarEnemigosMuertos();
            gm.ActualizarPuntos(50);
            

        }*/
    }





}