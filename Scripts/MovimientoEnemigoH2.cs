using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigoH2 : MonoBehaviour
{


    // MOVIMIENTO ENEMIGO ENTRE DOS DISTANCIAS


    public float posicitonInicial;
    public float velEnemigo=1;
    public float movimiento = 1f;
    public bool mirandoDerecha;

    //VARIABLES RAYCAST
    public GameObject RayoIzq;
    public GameObject RayoDerecha;
    public GameObject RayoArriba;
    public GameObject RayoAbajo;

    private Vector3 InicioRayoDerecha;
    private Vector3 FinRayoDerecha;
    private Vector3 InicioRayoIzquierda;
    private Vector3 FinRayoIzquerda;
    private Vector3 InicioRayoSuperior;
    private Vector3 FinRayoSuperior;
    private Vector3 InicioRayoCaida;
    private Vector3 FinRayoCaida;
    public float ajusteRaycast = 0;

    public GameObject Goblin;
    public GameObject Pie;


    public float velX = 1;
    

    public bool muerte;


    public int estado = 0;//0 movimiento  1- Muerte 

    public CircleCollider2D colliderMuerte;

    Animator animator;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start(){
        animator = GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
        posicitonInicial = this.transform.position.x;
        Goblin = GameObject.FindGameObjectWithTag("goblin");
        Pie = GameObject.FindGameObjectWithTag("Pie");
    }
    void Update() {



        //RAYCAST 2D

        //RAYO DERECHA
        InicioRayoDerecha = RayoDerecha.transform.position;
        FinRayoDerecha = new Vector3(RayoDerecha.transform.position.x + ajusteRaycast, RayoDerecha.transform.position.y, 0);

        RaycastHit2D hitDerecha = Physics2D.Linecast(InicioRayoDerecha, FinRayoDerecha);
        Debug.DrawLine(InicioRayoDerecha, FinRayoDerecha, Color.cyan);

        if (hitDerecha.collider != null)
        {
            if (hitDerecha.collider.gameObject != Goblin)
            {
                //Debug.Log("toca");

                CambioDireccion();
            }

            if (hitDerecha.collider.gameObject.tag == "goblin")
            {
                //Destroy(Goblin);
            }
        }

        //RAYO IZQUIERDA
        InicioRayoIzquierda = RayoIzq.transform.position;
        FinRayoIzquerda = new Vector3(RayoIzq.transform.position.x - ajusteRaycast, RayoIzq.transform.position.y, 0);

        RaycastHit2D hitIzquierda = Physics2D.Linecast(InicioRayoIzquierda, FinRayoIzquerda);
        Debug.DrawLine(InicioRayoIzquierda, FinRayoIzquerda, Color.cyan);

        if (hitIzquierda.collider != null)
        {
            if (hitIzquierda.collider.gameObject != Goblin)
            {

                CambioDireccion();
                //Debug.Log("toca");
            }
            if (hitIzquierda.collider.gameObject.tag == "goblin")
            {
                //Debug.Log("toca");
                // Destroy(Goblin);
            }
        }

        //RAYO SUPERIOR
        InicioRayoSuperior = RayoArriba.transform.position;
        FinRayoSuperior = new Vector3(RayoArriba.transform.position.x, RayoArriba.transform.position.y + ajusteRaycast, 0);

        RaycastHit2D hitSuperior = Physics2D.Linecast(InicioRayoSuperior, FinRayoSuperior);
        Debug.DrawLine(InicioRayoSuperior, FinRayoSuperior, Color.cyan);
        if (hitSuperior.collider != null)
        {
            if (hitSuperior.collider.gameObject == Pie)
            {

                StartCoroutine(Muerte());
            }
        }

        //DETECCION CAIDA
        InicioRayoCaida = RayoAbajo.transform.position;
        FinRayoCaida = new Vector3(RayoAbajo.transform.position.x, RayoAbajo.transform.position.y - ajusteRaycast, 0);

        RaycastHit2D hitCaida = Physics2D.Linecast(InicioRayoCaida, FinRayoCaida);
        Debug.DrawLine(InicioRayoCaida, FinRayoCaida, Color.cyan);

        if (hitCaida.collider == null )
        {
            CambioDireccion();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       if (mirandoDerecha){
            if(this.transform.position.x > posicitonInicial + movimiento) {
                mirandoDerecha = false;
                this.transform.localScale = new Vector3(-1f, 1f, 1f);
            }else{
                this.rb.velocity = new Vector3(velEnemigo, rb.velocity.y, 0);
                animator.SetFloat("velX", velEnemigo);
            }
        } else{
            if (this.transform.position.x < posicitonInicial - movimiento){
                mirandoDerecha = true;
                this.transform.localScale = new Vector3(1f, 1f, 1f);
            }else{
                this.rb.velocity = new Vector3(-velEnemigo, rb.velocity.y, 0);
                animator.SetFloat("velX", velEnemigo);
            }
        }

    }
    void CambioDireccion()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.localScale = new Vector3(transform.localScale.x * -1f, 1f, 1f);
        velX *= -1;
    }
    public IEnumerator Muerte()
    {
        rb.velocity = Vector2.zero;
        animator.SetBool("muertePisada", true);
        GetComponent<Collider2D>().isTrigger = true;
        rb.isKinematic = true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    /*
    //Como matar a emenigo y desaparezca
    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "goblin"){
            //Debug.Log("toca");
           float yOffset = 0.4f;
          if (transform.position.y + yOffset < col.transform.position.y) {
                col.SendMessage("EmemigoSalto");
                Destroy(gameObject);
            }
            
            
        }
    }*/
}
