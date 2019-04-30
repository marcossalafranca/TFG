using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text vidatext;
    public Text timetext;
    public Text monedatext;
    public Text puntostext;
    public Text rubitext;
    public Text muertostext;

    public GameObject pausa;
    bool paused;


    public int puntosActuales = 0;
    public int monedasActuales = 0;
    public float tiempoActuales = 300;
    public float mintime = 0f;
    public int vidasActuales = 3;
    public int rubisActuales = 0;
    public int muertos = 0;


    public bool muerto = false;
    public GameObject go;
    public GameObject fake;
    public bool tiempomuerto;

    void Update()
    {

        
            tiempoActuales -= Time.deltaTime;
            timetext.text = tiempoActuales.ToString("f0");
            if (tiempoActuales == mintime)
        {
            tiempoActuales = 0f;
            tiempomuerto = true;
        }
           

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {  //cridar a  per a que apareca pause
                Pausa();
            }


            if (paused)
            {                 //  parar el juego
                Time.timeScale = 0;

            }
            else
            {
                Time.timeScale = 1;
            }
            if (tiempoActuales <1)
            {
                tiempoActuales = 0;
                tiempomuerto = true;
            }

        
        
    }

    public void ActualizarVidas()
    {
        vidasActuales += 1;
        vidatext.text = vidasActuales.ToString();


    }


    public void ActualizarEnemigosMuertos()
    {
        muertos += 1;
        ActualizarPuntos(50);
        muertostext.text = muertos.ToString();


    }

    public void RestarVidas()
    {

        if (vidasActuales > 1)
        {
            muerto = false;
            vidasActuales -= 1;
            vidatext.text = vidasActuales.ToString();

            

        }
        else
        {
            vidasActuales = 0;
            vidatext.text = vidasActuales.ToString();
            muerto = true;


            go.SetActive(true);

        }
    }

    public void ActualizarMonedas()
    {

        if (monedasActuales == 99)
        {
            monedasActuales = 0;
            ActualizarVidas();
        }
        else
        {
            monedasActuales += 1;
        }
        monedatext.text = monedasActuales.ToString();
    }


    public void ActualizarPuntos(int puntos)
    {
        puntosActuales += puntos;
        puntostext.text = puntosActuales.ToString();
    }

    public void ActualizarRubi()
    {

        rubisActuales += 1;
        rubitext.text = rubisActuales.ToString();





    }

    void Pausa()
    {

        paused = !paused;//camvi de estat de pausa
        pausa.SetActive(paused);


    }
}