using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformacau : MonoBehaviour{

    //PLATAFORMA QUE AL TOCAR DESAPAREIX 

    private Rigidbody2D rb;
    private BoxCollider2D pc2d;
  
    private Vector3 start;
    public GameObject plataforma;
    public float tiempoDesaparecer;
    public float tiempoCaer;
    public float restaurar;
    public GameManager gm;

    AudioSource sonido;
    public AudioClip soCaiguda;

    // Start is called before the first frame update
    void Start(){

        rb = GetComponent<Rigidbody2D>();
        pc2d = GetComponent<BoxCollider2D>();
        
        start = transform.position;
        sonido = GetComponent<AudioSource>();
        gm = FindObjectOfType<GameManager>();
    }


    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("goblin")) { // si toca goblin

            Invoke("Caida", tiempoCaer);  //provocar caida plataforma

            Invoke("Desaparecer", tiempoDesaparecer);

            Invoke("Restaurar", restaurar); //Restaurar plataforma
        }
    }

    void Caida() {
        rb.isKinematic = false;
    }

    void Desaparecer(){

        if (gm.GetComponent<Botons>().fxOn == false){

            gm.GetComponent<AudioSource>().clip = gm.audicaigudaPlataforma;
            gm.GetComponent<AudioSource>().Play();
        }

        plataforma.SetActive(false); 
        

    }

    void Restaurar(){

        plataforma.SetActive(true);
        transform.position = start;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        pc2d.isTrigger = false;

    }

    
    }
