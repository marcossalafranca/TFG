using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{

    public Text vidatext;
    public Text timetext;
    public Text monedatext;
    public Text puntostext;
    public Text rubitext;
    public Text muertostext;
    public Text norubis1;


    public GameObject pausa;
    bool paused;


    public int puntosActuales = 0;
    public int monedasActuales = 0;
    public float tiempoActuales;
    public float mintime = 0f;
    public int vidasActuales ;
    public int rubisActuales ;
    public int muertos = 0;
    public int rubisfalten;

   
    public bool nivell1;
    public bool nivell2;
    public bool nivell3;


    public GameObject t;

    public bool muerto=true;
    public GameObject go;
    public GameObject FiJuego;
    public GameObject juego;



    public GameManager gm;
    public bool finJuego;
    bool tiempomuerto=true;

    //SO

    public AudioClip audioVida;
    public AudioClip audioMuerte;
    public AudioClip audiomoneda;
    public AudioClip audioRubi;
    public AudioClip audioGameover;
    public AudioClip audicaigudaPlataforma;
    public AudioClip audioMusica;
    public AudioClip audioSaltTrampoli;

    AudioSource sonido;
    public int so;
    public int fx;

    public bool musicaOff;
    public bool fxOOff;

    public GameObject musica;
    public bool repetir;


    void Awake(){
        repetir = GetComponent<Botons>().repetir;
        sonido= GetComponent<AudioSource>();
        gm = FindObjectOfType<GameManager>();
       
        so = PlayerPrefs.GetInt("So");
        fx = PlayerPrefs.GetInt("Fx");
       

        if (nivell2 ) {

       
            vidasActuales = PlayerPrefs.GetInt("nivell1");
            vidatext.text = vidasActuales.ToString();
        }

        if (nivell3)
        {

            vidasActuales = PlayerPrefs.GetInt("nivell2");
            vidatext.text = vidasActuales.ToString();
        }

    }


    void Update(){

        if (so == 1){
            gm.GetComponent<Botons>().MusicaOff();
          
        }

        if (fx == 1){

            gm.GetComponent<Botons>().FxOff();
          
        }

        finJuego = FiJuego.GetComponent<Casa>().fin;
        

        if (tiempomuerto==true && tiempoActuales>0 && !muerto && finJuego==false){
            tiempoActuales -= Time.deltaTime;
            timetext.text = tiempoActuales.ToString("f0");
            
        }

        if (tiempoActuales<0){
            Gameover();
            
        }
           

        if (Input.GetKeyDown(KeyCode.Escape) ){  //cridar a  per a que apareca pause
              Pausa();
        }


       if (paused){                 //  parar el juego
             Time.timeScale = 0;

       }else{
                Time.timeScale = 1;
       }
        
    }

    public void pararTiempo() {
        Time.timeScale = 0;
    }
    
    public void Gameover(){

        if (tiempomuerto){
            if (gm.GetComponent<Botons>().fxOn == false){
                sonido.clip = audioMuerte;
                sonido.Play();
            }

            RestarVidas();
            t.GetComponent<Moviment>().GoblimMuerte = true;        
            tiempoActuales = 0;
            tiempomuerto = true;
           
        }
        
    }

    public void ActualizarVidas(){
        if (gm.GetComponent<Botons>().fxOn == false){
            sonido.clip = audioVida;
            sonido.Play();
        }

        vidasActuales += 1;
        vidatext.text = vidasActuales.ToString();


    }


    public void ActualizarEnemigosMuertos(){

        muertos += 1;
        ActualizarPuntos(50);
        muertostext.text = muertos.ToString();
    }

    public void RestarVidas(){

        if (vidasActuales > 1){
            if (gm.GetComponent<Botons>().fxOn == false){
                sonido.clip = audioMuerte;
                sonido.Play();
            }

            muerto = false;
            vidasActuales -= 1;
            vidatext.text = vidasActuales.ToString();

        }else{

            if (gm.GetComponent<Botons>().fxOn == false){
                sonido.clip = audioGameover;
                sonido.Play();
            }

            vidasActuales = 0;
            vidatext.text = vidasActuales.ToString();
            muerto = true;
            go.SetActive(true);

        }
    }

    public void ActualizarMonedas(){

        if (monedasActuales == 99){
            if (gm.GetComponent<Botons>().fxOn == false){
                sonido.clip = audioVida;
                sonido.Play();
            }

            monedasActuales = 0;
            ActualizarVidas();
        }else{

            if (gm.GetComponent<Botons>().fxOn == false){
                sonido.clip = audiomoneda;
                sonido.Play();
            }

            monedasActuales += 1;
        }

        monedatext.text = monedasActuales.ToString();
    }


    public void ActualizarPuntos(int puntos){
        puntosActuales += puntos;
        puntostext.text = puntosActuales.ToString();
    }

    public void ActualizarRubi(){

        if (gm.GetComponent<Botons>().fxOn == false){
            sonido.clip = audioRubi;
            sonido.Play();
        }

        rubisActuales += 1;
        rubitext.text = rubisActuales.ToString();
        rubisfalten = 3 - rubisActuales;
        norubis1.text = rubisfalten.ToString();
    }

    public void Pausa() {

        paused = !paused;    //camvi de estat de pausa
        pausa.SetActive(paused);


    }
}