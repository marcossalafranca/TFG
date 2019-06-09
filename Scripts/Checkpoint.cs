using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject Goblin;
    public GameObject text1;
    public ParticleSystem particula;
    public GameManager gm;

    public bool nivell1;
    public bool nivell2;
    public bool nivell3;

    public bool checkpoint;
    public bool checkpoint2;
    public bool checkpoint3;
    Animator animator;

   

    AudioSource sonido;

    // Start is called before the first frame update
    void Start(){
        Goblin = GameObject.FindGameObjectWithTag("goblin");
        animator = GetComponent<Animator>();
        sonido = GetComponent<AudioSource>();
        gm = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject == Goblin && nivell1){

            if (gm.GetComponent<Botons>().fxOn == false) {
                sonido.Play();
            }

            animator.SetBool("toca", true);
            this.checkpoint = true;
            particula.Stop();
            text1.SetActive(true);
            Invoke("DesactivarTexto",2);

        }

        if (collision.gameObject == Goblin && nivell2){

            if (gm.GetComponent<Botons>().fxOn == false) {
                sonido.Play();
            }

            animator.SetBool("toca", true);
            this.checkpoint2 = true;
            particula.Stop();
            text1.SetActive(true);
            Invoke("DesactivarTexto", 2);

        }

        if (collision.gameObject == Goblin && nivell3){

            if (gm.GetComponent<Botons>().fxOn == false){
                sonido.Play();
            }

            animator.SetBool("toca", true);
            this.checkpoint3 = true;
            particula.Stop();
            text1.SetActive(true);
            Invoke("DesactivarTexto", 2);

        }
    }
   

    public void DesactivarTexto(){

   
        text1.SetActive(false);
        animator.SetBool("toca", false);
    }

}
