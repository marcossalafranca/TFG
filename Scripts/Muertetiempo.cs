using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muertetiempo : MonoBehaviour
{

    public GameObject goblin;
    bool muerteGoblin;
    public GameManager gm;
    public bool  tiempo0;


    void Awake()
    {

        gm = FindObjectOfType<GameManager>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo0= gm.GetComponent<GameManager>().tiempomuerto;

        if (tiempo0){
            Debug.Log("toca");
           // goblin.GetComponent<Movimiento>().GoblimMuerte = true;
           // gm.RestarVidas();
            
        }
    }
}
