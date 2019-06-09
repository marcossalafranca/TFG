using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public GameObject Goblin;
    public GameObject text;
    public GameObject text2;
    public GameObject text3;
    public GameManager gm;


    public GameObject music;
    public GameObject musicA;
    AudioSource sonido;
    AudioSource sonidoA;

    bool fxOn;
    bool musicaON;
    public bool fin;

    void Awake(){

        gm = FindObjectOfType<GameManager>();
        sonido = music.GetComponent<AudioSource>();
        sonidoA = musicA.GetComponent<AudioSource>();
    }

    void Start(){
        Goblin = GameObject.FindGameObjectWithTag("goblin");

    }

    void Update(){
        fxOn = gm.GetComponent<Botons>().fxOn;
        musicaON = gm.GetComponent<Botons>().musicaOn;

    }

    //Si toca goblin


    void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject == Goblin && gm.rubisActuales==3 || gm.rubisActuales >3) {
            if (gm.GetComponent<Botons>().fxOn == false) {
                sonido.Stop();
            }

            fin = true;
            text.SetActive(true);
            Time.timeScale = 0;
           
          
            Goblin.GetComponent<AudioListener>().enabled = false;
            Goblin.SetActive(false);
            GetComponent<AudioListener>().enabled = true;

            if (!fxOn){
                if (gm.GetComponent<Botons>().fxOn == false){
                    sonidoA.Play();
                }
            }

         
        }

        if (collision.gameObject == Goblin && gm.rubisActuales <2){
            text2.SetActive(true);
        }

        if (collision.gameObject == Goblin && gm.rubisActuales ==2){
            text3.SetActive(true);
        }

    }
    
    private void OnTriggerExit2D(Collider2D collision) {
        text2.SetActive(false);
        text3.SetActive(false);
    }

}
