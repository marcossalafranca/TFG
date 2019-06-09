using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hada : MonoBehaviour{
    public GameObject Goblin;
    public GameObject textnegro;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject boto1;

    public bool hada;
    public bool hada1;
    public bool hada2;
    public bool hada3;
    public bool hada4;

    public GameObject fada;

    public bool haParlat;


    void Start(){
        Goblin = GameObject.FindGameObjectWithTag("goblin");
  
    }


    //Si toca  goblin

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject == Goblin){  //&& haParlat == false  si es vol que una vegada a parlat no torne a eixir
 
            textnegro.SetActive(true);
            fada.SetActive(true);

            if (hada) {
                text1.SetActive(true);
            }

            if (hada1){
                text2.SetActive(true); 
            }

            if (hada2){
                text3.SetActive(true);
            }

            if (hada3){
                text4.SetActive(true);
            }

            if (hada4){
                text5.SetActive(true);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision){


        textnegro.SetActive(false);

        if (hada) {
            text1.SetActive(false);
            Invoke ("DesaparecerHada",2f);
      
        }

        if (hada1){
            text2.SetActive(false);
            Invoke("DesaparecerHada", 2f);
   
        }

        if (hada2){
            text3.SetActive(false);

        }

        if (hada3){
            text4.SetActive(false);
   
        }

        if (hada4){
            text5.SetActive(false);

        }
    }


    void AparecerHada(){
        fada.SetActive(true);
    }

    void DesaparecerHada(){
        fada.SetActive(false);
    }
    
}
