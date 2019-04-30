using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hada : MonoBehaviour
{
    public GameObject Goblin;
    public GameObject textnegro;
    public GameObject text1;
    public GameObject text2;
    public GameObject boto1;
    
    public GameManager gm;

    public bool haParlat;

    public GameObject hada;

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

    //Si toca  goblin

     void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject == Goblin && haParlat== false)
        {
            haParlat = true;
            textnegro.SetActive(true);
            //Time.timeScale = 0;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textnegro.SetActive(false);
        
     
    }

    
    
     
    
}
