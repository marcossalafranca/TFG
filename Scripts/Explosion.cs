using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject Goblin;
    bool muerteGoblin;
    public CircleCollider2D c;

    void Start() {
        Goblin = GameObject.FindGameObjectWithTag("goblin");
    }
     void Update() {
        muerteGoblin = Goblin.GetComponent<Movimiento>().GoblimMuerte;
    }

    //Si toca que muera goblin

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Goblin){

            Goblin.GetComponent<Movimiento>().GoblimMuerte = true;
        }
       
    }



}
       
