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


    int puntosActuales = 0;
    int monedasActuales = 0;
    float tiempoActuales = 300;
    int vidasActuales = 3;
    int rubisActuales = 0;
    public bool totRubi = false;

    void Update()
    {
        tiempoActuales -= Time.deltaTime;
        timetext.text = tiempoActuales.ToString("f0");

    }

    public void ActualizarVidas()
    {
        vidasActuales += 1;
        vidatext.text = vidasActuales.ToString();
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
        if (rubisActuales < 4)
        {
            rubisActuales += 1;
            rubitext.text = rubisActuales.ToString();
        }
        else
        {
            totRubi = true;
        }
    }
}
