using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaigudaV : MonoBehaviour
{
    public GameObject Goblin;
    public GameObject vacio;
    bool muerteGoblin;
    public GameManager gm;

    void Awake(){

        gm = FindObjectOfType<GameManager>();

    }

    void Start(){
        Goblin = GameObject.FindGameObjectWithTag("goblin");

    }

    void Update() {

        muerteGoblin = Goblin.GetComponent<Moviment>().GoblimMuerte;
       
    }

    //Si toca que mor goblin

    private void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject == Goblin && !muerteGoblin){

            Goblin.GetComponent<Moviment>().GoblimMuerte = true;
            vacio.SetActive(false);
            gm.RestarVidas();

        }
    }




}
