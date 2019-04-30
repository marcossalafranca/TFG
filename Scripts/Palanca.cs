using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    public GameManager gm;
    public GameObject Goblin;
    public GameObject pared;
    public GameObject palo;

    public bool abierto= false;   
    

    Animator animator;
    private SpriteRenderer spr;
    void Awake()
    {
        animator = GetComponent<Animator>();
        gm = FindObjectOfType<GameManager>();
        
    }

    void Start()
    {
        Goblin = GameObject.FindGameObjectWithTag("goblin");
       
    }


    //Si toca  goblin

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Goblin)
        { 
            animator.SetBool("toca", true);
            Destroy(palo);
            //pared.GetComponent<BoxCollider2D>().isTrigger=true;

     
        }

    }
    

}
