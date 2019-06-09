using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosioBomba : MonoBehaviour{

    public GameObject Goblin;
    bool muerteGoblin;
    public bool explota;
    public bool tocado;
    public GameManager gm;
    AudioSource sonido;

    void Awake(){

        gm = FindObjectOfType<GameManager>();
        sonido = GetComponent<AudioSource>();
    }

    void Start() {
        Goblin = GameObject.FindGameObjectWithTag("goblin");
        
    }
     void Update() {
        muerteGoblin = Goblin.GetComponent<Moviment>().GoblimMuerte;

        if (!explota) {

            if (gm.GetComponent<Botons>().fxOn == false){
                sonido.Play();
            }

            explota = true;
        }
        
    }

    //Si toca mor goblin

      void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject == Goblin){
            
            gm.RestarVidas();
            tocado = true;
            Goblin.GetComponent<Moviment>().GoblimMuerte = true;
            
        }
       
    }



}
       
  