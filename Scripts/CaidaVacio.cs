using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaVacio : MonoBehaviour
{
    public GameObject Goblin;
    public GameObject vacio;
    bool muerteGoblin;
    public GameManager gm;

    void Awake()
    {

        gm = FindObjectOfType<GameManager>();

    }

    void Start()
    {
        Goblin = GameObject.FindGameObjectWithTag("goblin");
    }
    void Update()
    {
        muerteGoblin = Goblin.GetComponent<Movimiento>().GoblimMuerte;
    }

    //Si toca que muera goblin

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Goblin)
        {

            Goblin.GetComponent<Movimiento>().GoblimMuerte = true;
            gm.RestarVidas();
            vacio.SetActive(false);
        }

    }



}
