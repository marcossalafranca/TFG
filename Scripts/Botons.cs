using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botons : MonoBehaviour
{

    public GameManager gm;
    public GameObject music;
    GameObject goblin;


    public AudioClip Boto;
   
    AudioSource fx;
    AudioSource sonido;
    AudioSource fxSo;

    public bool fxOn;
    public bool musicaOn;
    public bool repetir=false;

     void Awake(){
        gm = FindObjectOfType<GameManager>();
        fx = GetComponent<AudioSource>();
  
        goblin = GameObject.FindWithTag("goblin");
        sonido = music.GetComponent<AudioSource>();
        fxSo = gm.GetComponent<AudioSource>();
       

    }

   

    public void FxOff(){
        fxOn = true;
        fxSo.Pause();
      
    }


    public void FxOn(){
        fxOn = false;
        fxSo.Play();
        PlayerPrefs.SetInt("Fx", 0);
        gm.GetComponent<GameManager>().fx = 0;

    }


    public void MusicaOff(){
        musicaOn = true;
        sonido.Pause();
     
    }


    public void MusicaOn(){
        musicaOn = false;
        sonido.Play();
        PlayerPrefs.SetInt("So", 0);
        gm.GetComponent<GameManager>().so = 0;
    }


    public void PulsarBoton(){
        if (!fxOn) {
            fx.clip = Boto;
            fx.Play();
        }
    }



   public void BotonJugar(){

        sonido.Stop();

        if (musicaOn){

            PlayerPrefs.SetInt("So", 1);

        }else{
            PlayerPrefs.SetInt("So", 0);

        }


        if (fxOn) {
            PlayerPrefs.SetInt("Fx", 1);

        }else{

            PlayerPrefs.SetInt("Fx", 0);
        }


    SceneManager.LoadScene("1");
    }



    public void BotonSalir(){
        sonido.Stop();
        Application.Quit();
    }



    public void BotonInicio() {

        SceneManager.LoadScene("Scenes/Main");
    }


    public void BotonSegonNivell() {
        if (musicaOn){

            PlayerPrefs.SetInt("So", 1);

        }else{

            PlayerPrefs.SetInt("So", 0);
        }


        if (fxOn){

            PlayerPrefs.SetInt("Fx", 1);

        } else{

            PlayerPrefs.SetInt("Fx", 0);
        }

     SceneManager.LoadScene("2");
    
    }


    public void BotonTercerNivell() {
        if (musicaOn) {

            PlayerPrefs.SetInt("So", 1);

        } else{

            PlayerPrefs.SetInt("So", 0);
        }

        if (fxOn) {

            PlayerPrefs.SetInt("Fx", 1);

        } else{

            PlayerPrefs.SetInt("Fx", 0);
        }

     SceneManager.LoadScene("3");
    }

  
    public void Repetir(){
        repetir = true;
    }
}
