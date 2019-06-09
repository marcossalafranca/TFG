using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocaMort : MonoBehaviour{
    public GameObject Goblin;
    bool muerteGoblin;
    public GameManager gm;

    void Awake(){

        gm = FindObjectOfType<GameManager>();

    }

    void Start() {
        Goblin = GameObject.FindGameObjectWithTag("goblin");
    }
     void Update() {
        muerteGoblin = Goblin.GetComponent<Moviment>().GoblimMuerte;
    }

    //Si toca que mor goblin

     void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject == Goblin){

            Goblin.GetComponent<Moviment>().GoblimMuerte = true;
            gm.RestarVidas();
        }
       
    }



}
       
  