using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemigoBomba : MonoBehaviour{


    // MOVIMIENTO ENEMIGO ENTRE DOS DISTANCIAS


    public float posicitonInicial;
    public float velEnemigo = 1;
    public float movimiento = 1f;
    public bool mirandoDerecha;

    //VARIABLES RAYCAST
    public GameObject Rayos;
    public GameObject DeteccionCaida;
    public GameObject DeteccionArriba;
    public GameObject DeteccionArriba2;

    private Vector3 InicioRayoDerecha;
    private Vector3 FinRayoDerecha;
    private Vector3 InicioRayoIzquierda;
    private Vector3 FinRayoIzquerda;
    private Vector3 InicioRayoSuperior;
    private Vector3 FinRayoSuperior;
    private Vector3 InicioRayoSuperior2;
    private Vector3 FinRayoSuperior2;
    private Vector3 InicioRayoCaida;
    private Vector3 FinRayoCaida;
    public float ajusteRaycast = 0;

    public GameObject Goblin;
    public GameObject Pie;
    public GameObject enemigo;


    public float velX = 1;


    public bool muerte;
    int estadoGoblin;
    bool muerteGoblin;

    public int estado = 0;//0 movimiento  1- Muerte 

    public CircleCollider2D colliderMuerte;

    Animator animator;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        posicitonInicial = this.transform.position.x;
        Goblin = GameObject.FindGameObjectWithTag("goblin");
        Pie = GameObject.FindGameObjectWithTag("Pie");
    }
    void Update()
    {

        estadoGoblin = Goblin.GetComponent<Movimiento>().estadoGoblin;
        muerteGoblin = Goblin.GetComponent<Movimiento>().GoblimMuerte;

        //RAYCAST 2D

        //RAYO DERECHA
        InicioRayoDerecha = Rayos.transform.position;
        FinRayoDerecha = new Vector3(Rayos.transform.position.x + ajusteRaycast, Rayos.transform.position.y, 0);

        RaycastHit2D hitDerecha = Physics2D.Linecast(InicioRayoDerecha, FinRayoDerecha);
        Debug.DrawLine(InicioRayoDerecha, FinRayoDerecha, Color.cyan);

        if (hitDerecha.collider != null)
        {
            if (hitDerecha.collider.gameObject != Goblin)
            {
                //Debug.Log("toca");

                CambioDireccion();
            }

            if (hitDerecha.collider.gameObject.tag == "goblin" && rb.velocity != Vector2.zero && !muerteGoblin)
            {
                //Goblin.GetComponent<Movimiento>().GoblinGolpeado = true;
                Goblin.GetComponent<Movimiento>().GoblimMuerte = true;

            }
        }

        //RAYO IZQUIERDA
        InicioRayoIzquierda = Rayos.transform.position;
        FinRayoIzquerda = new Vector3(Rayos.transform.position.x - ajusteRaycast, Rayos.transform.position.y, 0);

        RaycastHit2D hitIzquierda = Physics2D.Linecast(InicioRayoIzquierda, FinRayoIzquerda);
        Debug.DrawLine(InicioRayoIzquierda, FinRayoIzquerda, Color.cyan);

        if (hitIzquierda.collider != null)
        {
            if (hitIzquierda.collider.gameObject != Goblin)
            {

                CambioDireccion();
                //Debug.Log("toca");
            }
            if (hitIzquierda.collider.gameObject.tag == "goblin" && rb.velocity != Vector2.zero && !muerteGoblin)
            {
                // Goblin.GetComponent<Movimiento>().GoblinGolpeado = true;
                Goblin.GetComponent<Movimiento>().GoblimMuerte = true;
            }
        }

        //RAYO SUPERIOR
        InicioRayoSuperior = DeteccionArriba.transform.position;
        FinRayoSuperior = new Vector3(DeteccionArriba.transform.position.x, DeteccionArriba.transform.position.y + ajusteRaycast, 0);

        RaycastHit2D hitSuperior = Physics2D.Linecast(InicioRayoSuperior, FinRayoSuperior);
        Debug.DrawLine(InicioRayoSuperior, FinRayoSuperior, Color.cyan);
        if (hitSuperior.collider != null)
        {
            if (hitSuperior.collider.gameObject == Pie && !muerteGoblin)
            {

                
                StartCoroutine(Muerte());
            }
        }
        InicioRayoSuperior2 = DeteccionArriba2.transform.position;
        FinRayoSuperior2 = new Vector3(DeteccionArriba2.transform.position.x, DeteccionArriba2.transform.position.y + ajusteRaycast, 0);

        RaycastHit2D hitSuperior2 = Physics2D.Linecast(InicioRayoSuperior2, FinRayoSuperior2);
        Debug.DrawLine(InicioRayoSuperior2, FinRayoSuperior2, Color.cyan);
        if (hitSuperior2.collider != null)
        {
            if (hitSuperior2.collider.gameObject == Pie && !muerteGoblin)
            {

              
                StartCoroutine(Muerte());
            }
        }
        //DETECCION CAIDA
        InicioRayoCaida = DeteccionCaida.transform.position;
        FinRayoCaida = new Vector3(DeteccionCaida.transform.position.x, DeteccionCaida.transform.position.y - ajusteRaycast, 0);

        RaycastHit2D hitCaida = Physics2D.Linecast(InicioRayoCaida, FinRayoCaida);
        Debug.DrawLine(InicioRayoCaida, FinRayoCaida, Color.cyan);

        if (hitCaida.collider == null)
        {
            CambioDireccion();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (mirandoDerecha)
        {
            if (this.transform.position.x > posicitonInicial + movimiento)
            {
                mirandoDerecha = false;
                this.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                this.rb.velocity = new Vector3(velEnemigo, rb.velocity.y, 0);
                animator.SetFloat("velX", velEnemigo);
            }
        }
        else
        {
            if (this.transform.position.x < posicitonInicial - movimiento)
            {
                mirandoDerecha = true;
                this.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
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
        velEnemigo = 0;
        //Destroy(Rayos);
        //ajusteRaycast = 0; //ponemos los rayos a cero para que no maten al goblin

        rb.velocity = Vector2.zero;
        animator.SetBool("moversepisado", true);
        yield return new WaitForSeconds(2.5f);
        ajusteRaycast = 0;
        

        rb.velocity = Vector2.zero;
        animator.SetBool("muertePisada", true);
        GetComponent<Collider2D>().isTrigger = true;
        enemigo= GameObject.Find("explosioncollider");
        enemigo.GetComponent<CircleCollider2D>().enabled = true;


        rb.isKinematic = true;
      
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }


   



}
