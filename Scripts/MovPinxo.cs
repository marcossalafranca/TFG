using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPinxo : MonoBehaviour
{


    // MOVIMIENT ENEMIG ENTRE DOS DISTANCIES


    public float posicitonInicial;
    public float velEnemigo = 1;
    public float movimiento = 1f;
    public bool mirandoDerecha;

    //VARIABLES RAYCAST
    public GameObject Rayos;
    public GameObject Rayos2;


    private Vector3 InicioRayoDerecha;
    private Vector3 FinRayoDerecha;
    private Vector3 InicioRayoIzquierda;
    private Vector3 FinRayoIzquerda;
    private Vector3 InicioRayoDerecha2;
    private Vector3 FinRayoDerecha2;
    private Vector3 InicioRayoIzquierda2;
    private Vector3 FinRayoIzquerda2;
    
    public float ajusteRaycast = 0;

    public GameObject Goblin;
    public GameObject Pie;
    GameManager gm;

    public float velX = 1;


    public bool muerte;
    int estadoGoblin;
    bool muerteGoblin;

   

    public CircleCollider2D colliderMuerte;

    Animator animator;
    Rigidbody2D rb;

     void Awake(){
        gm = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start(){
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        posicitonInicial = this.transform.position.x;
        Goblin = GameObject.FindGameObjectWithTag("goblin");
        Pie = GameObject.FindGameObjectWithTag("Pie");
    }
    void Update(){

        estadoGoblin = Goblin.GetComponent<Moviment>().estadoGoblin;
        muerteGoblin = Goblin.GetComponent<Moviment>().GoblimMuerte;

        //RAYCAST 2D

        //RAY DRETA
        InicioRayoDerecha = Rayos.transform.position;
        FinRayoDerecha = new Vector3(Rayos.transform.position.x + ajusteRaycast, Rayos.transform.position.y, 0);

        RaycastHit2D hitDerecha = Physics2D.Linecast(InicioRayoDerecha, FinRayoDerecha);
        Debug.DrawLine(InicioRayoDerecha, FinRayoDerecha, Color.cyan);

        if (hitDerecha.collider != null){
            if (hitDerecha.collider.gameObject != Goblin){
              

                CambioDireccion();
            }

            if (hitDerecha.collider.gameObject.tag == "goblin" && rb.velocity != Vector2.zero && !muerteGoblin){
                
                Goblin.GetComponent<Moviment>().GoblimMuerte = true;
                gm.RestarVidas();
            }
        }

        //RAY DRETA 2
        InicioRayoDerecha2 = Rayos2.transform.position;
        FinRayoDerecha2 = new Vector3(Rayos2.transform.position.x + ajusteRaycast, Rayos2.transform.position.y, 0);

        RaycastHit2D hitDerecha2 = Physics2D.Linecast(InicioRayoDerecha2, FinRayoDerecha2);
        Debug.DrawLine(InicioRayoDerecha2, FinRayoDerecha2, Color.cyan);

        if (hitDerecha2.collider != null) {
            if (hitDerecha2.collider.gameObject != Goblin){
        

                CambioDireccion();
            }

            if (hitDerecha2.collider.gameObject.tag == "goblin" && rb.velocity != Vector2.zero && !muerteGoblin){
       
                Goblin.GetComponent<Moviment>().GoblimMuerte = true;
                gm.RestarVidas();
            }
        }

        //RAY ESQUERRA
        InicioRayoIzquierda = Rayos.transform.position;
        FinRayoIzquerda = new Vector3(Rayos.transform.position.x - ajusteRaycast, Rayos.transform.position.y, 0);

        RaycastHit2D hitIzquierda = Physics2D.Linecast(InicioRayoIzquierda, FinRayoIzquerda);
        Debug.DrawLine(InicioRayoIzquierda, FinRayoIzquerda, Color.cyan);

        if (hitIzquierda.collider != null) {
            if (hitIzquierda.collider.gameObject != Goblin){

                CambioDireccion();
              
            }
            if (hitIzquierda.collider.gameObject.tag == "goblin" && rb.velocity != Vector2.zero && !muerteGoblin){
               
                Goblin.GetComponent<Moviment>().GoblimMuerte = true;
                gm.RestarVidas();
            }
        }

        //RAY ESQUERRA2
        InicioRayoIzquierda2 = Rayos2.transform.position;
        FinRayoIzquerda2 = new Vector3(Rayos2.transform.position.x - ajusteRaycast, Rayos2.transform.position.y, 0);

        RaycastHit2D hitIzquierda2 = Physics2D.Linecast(InicioRayoIzquierda2, FinRayoIzquerda2);
        Debug.DrawLine(InicioRayoIzquierda2, FinRayoIzquerda2, Color.cyan);

        if (hitIzquierda2.collider != null){
            if (hitIzquierda2.collider.gameObject != Goblin){

                CambioDireccion();
             
            }
            if (hitIzquierda2.collider.gameObject.tag == "goblin" && rb.velocity != Vector2.zero && !muerteGoblin){
              
                Goblin.GetComponent<Moviment>().GoblimMuerte = true;
                gm.RestarVidas();
            }
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (mirandoDerecha){
            if (this.transform.position.x > posicitonInicial + movimiento){
                mirandoDerecha = false;
                this.transform.localScale = new Vector3(-1f, 1f, 1f);

            }else{

                this.rb.velocity = new Vector3(velEnemigo, rb.velocity.y, 0);
                animator.SetFloat("velX", velEnemigo);
            }
        }else{

            if (this.transform.position.x < posicitonInicial - movimiento) {
                mirandoDerecha = true;
                this.transform.localScale = new Vector3(1f, 1f, 1f);

            }else {

                this.rb.velocity = new Vector3(-velEnemigo, rb.velocity.y, 0);
                animator.SetFloat("velX", velEnemigo);
            }
        }

    }
    void CambioDireccion(){
        mirandoDerecha = !mirandoDerecha;
        transform.localScale = new Vector3(transform.localScale.x * -1f, 1f, 1f);
        velX *= -1;
    }

    public IEnumerator Muerte(){
        velEnemigo = 0;
        
        rb.velocity = Vector2.zero;
        animator.SetBool("muertePisada", true);
        GetComponent<Collider2D>().isTrigger = true;
        rb.isKinematic = true;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

}
