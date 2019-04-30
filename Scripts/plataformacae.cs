﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformacae : MonoBehaviour
{     
    //PLATAFORMA QUE AL TOCAR DESAPARECEN (PUEDEN VOLVER A APARECER O NO)


    private Rigidbody2D rb;
    private BoxCollider2D pc2d;
    //Los que estan en comentario son para que la al cabo de unos segundos se restaure la plataforma


    //private Vector3 start; 
    private Vector3 start;

    public float tiempoDesaparecer;
    public float tiempoCaer;
    public float restaurar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pc2d = GetComponent<BoxCollider2D>();
        // start = transform.position;
        start = transform.position;
    }
        // Update is called once per frame
        void Update()
        {

        }
        private void OnCollisionEnter2D(Collision2D collision) {

            if (collision.gameObject.CompareTag("goblin")) { // si toca goblin
                Invoke("Caida", tiempoCaer);  //provocar caida plataforma
                  //Invoke("Restaurar", tiempoCaer + restaurar);
                Invoke("Restaurar", tiempoCaer + restaurar); //Restaurar plataforma
            }
        }
        void Caida() {
            rb.isKinematic = false;
            //La linea de abajo hay que anularla si se quiere restaurar plataformas, si no se restaura borra la plataforma
           //Destroy(gameObject, tiempoDesaparecer);
        }

        /*  void Restaurar()
          {
              transform.position = start;
              rb.isKinematic = true;
              rb.velocity = Vector3.zero;
              pc2d.isTrigger =false;

          }*/
        void Restaurar()
        {
            transform.position = start;
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            pc2d.isTrigger = false;
        } 
    }
