using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour{

    public GameManager gm;
    public GameObject Goblin;
    public GameObject pared;
    public GameObject palo;

    public bool abierto= false;

    AudioSource sonido;

    Animator animator;
    private SpriteRenderer spr;

    void Awake() {

        sonido = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        gm = FindObjectOfType<GameManager>();
        
    }

    void Start(){
        Goblin = GameObject.FindGameObjectWithTag("goblin");
       
    }

     void Update(){

        if (!abierto){
            animator.SetBool("toca", false);
        }
    }

    //Si toca  goblin

    void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject == Goblin && !abierto){

            if (gm.GetComponent<Botons>().fxOn == false){
                sonido.Play();
            }

            animator.SetBool("toca", true);
            palo.SetActive(false);
            abierto = true;

        }

    }
    

}
