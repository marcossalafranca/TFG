using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardarvida : MonoBehaviour{
    public GameObject gm;

    public int vidas;
    public bool nivell1;
    public bool nivell2;
    public bool nivell3;

    // Start is called before the first frame update
    public void Update() {
       

        nivell1 = gm.GetComponent<GameManager>().nivell1;

        if (nivell1) {
            vidas = gm.GetComponent<GameManager>().vidasActuales;
            PlayerPrefs.SetInt("nivell1", vidas);
        }


       nivell2= gm.GetComponent<GameManager>().nivell2;

        if (nivell2){
            vidas = gm.GetComponent<GameManager>().vidasActuales;
            PlayerPrefs.SetInt("nivell2", vidas);
        }

        nivell3 = gm.GetComponent<GameManager>().nivell2;

        if (nivell3){
            vidas = gm.GetComponent<GameManager>().vidasActuales;
            PlayerPrefs.SetInt("nivell3", vidas);
        }
    }

}
