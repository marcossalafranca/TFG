using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public GameObject Goblin;
    public GameObject text;
    public GameObject text2;
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
   
    }

    //Si toca goblin

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Goblin && gm.rubisActuales==3)
        {
            text.SetActive(true);
            Time.timeScale = 0;
            Goblin.SetActive(false);
        }
        else
        {
            text2.SetActive(true);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        text2.SetActive(false);
    }

}
