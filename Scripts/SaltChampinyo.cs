using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltChampinyo : MonoBehaviour{

    public GameObject Goblin;
    public GameManager gm;
    
    Rigidbody2D rb;
    AudioSource sonido;
    public bool isgrounded;

    void Awake(){
        sonido = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
    }

    void Start() {
        Goblin = GameObject.FindGameObjectWithTag("goblin");
        isgrounded = true;
    }
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject == Goblin){

            Goblin.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 600));

            if (gm.GetComponent<Botons>().fxOn==false){
                sonido.Play();
            }
        }
        
    }

   
}
