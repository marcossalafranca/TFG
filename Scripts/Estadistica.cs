using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Estadistica : MonoBehaviour{

    public Text vidatext;
    public Text timetext;
    public Text monedatext;
    public Text puntostext;
    public Text rubitext;
    public Text muertostext;
    public GameManager gm;


    

    // Start is called before the first frame update
    void Start(){
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        vidatext.text = gm.vidasActuales.ToString();
        muertostext.text =gm.muertos.ToString();
        timetext.text = gm.tiempoActuales.ToString("f0");
        monedatext.text = gm.monedasActuales.ToString();
        puntostext.text = gm.puntosActuales.ToString();
        rubitext.text = gm.rubisActuales.ToString();
    }
}
