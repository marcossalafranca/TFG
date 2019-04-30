using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject bola;
    public GameObject bolaposicion;

    

    public float tiempoDisparo;
    float disparoCuenta;

    private Transform goblinTrans;
    Rigidbody2D bolaRB;
    public float bolaVelocidad;


    public float bolalife;




     void Awake(){
        goblinTrans  = GameObject.FindGameObjectWithTag("captus").transform.GetComponent<Transform>();
        bolaRB = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start(){

        if (goblinTrans.localPosition.x < transform.localPosition.x){
             bolaRB.velocity = new Vector2(-bolaVelocidad,bolaRB.velocity.y);
            GetComponent<SpriteRenderer>().flipY = false;
        }
        else{

            bolaRB.velocity = new Vector2(bolaVelocidad, bolaRB.velocity.y);
            GetComponent<SpriteRenderer>().flipY = true;
        }
    }

    // Update is called once per frame
    void Update(){
        //tiempo espera
        disparoCuenta += Time.deltaTime;

        if(disparoCuenta>= tiempoDisparo)
        {
            Instantiate(bola, bolaposicion.transform.position, bola.transform.rotation);
            disparoCuenta = 0;
        }

        Destroy(gameObject, bolalife);
    }

    
}
