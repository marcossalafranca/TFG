using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour {



    public GameObject goblin;

	//VARIABLES MOVIEMIENTO
	public float velX;
    float inputX;
    float posIniIFin;

    public bool mirandoDerecha;

	//VARIABLES DE SALTO
	public float fuerzaSalto;
	public Transform pie;
	public float radioPie = 0.08f;
	public LayerMask suelo;
	public bool enSuelo;
    private bool jump;

	//VARIABLES AGACHADO
	public bool agachado;
   

    //VARIABLES MIRAR ARRIBA
    public bool mirarArriba; 

	//VARIABLES CAIDA
	public float caida;
	Rigidbody2D rb;

	//VARIABLES CORRER
	public bool run;

	
    

    //ANIMACIONES
    private SpriteRenderer spr;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
      

    }
    //GOLPEAR GOBLIN
    public bool GoblinGolpeado;
    Color alpha;
    Color goblinAlpha;

    public GameObject[] allObjets;
    public GameObject[] enemigo;

    //VARIABLE MUERTE
    public CircleCollider2D colliderMuertegoblin;
    public CircleCollider2D colliderMuertePie;
    
    public bool GoblimMuerte;
    public int estadoGoblin;

    // Use this for initialization
    void Start () {
       


    }
    void Update() {



        //SALTO    metido aqui para que no de fallo al salto
        if (enSuelo)
        {//Si estoy en el suelo

            animator.SetBool("enSuelo", true);//Le digo al animador que estoy en el suelo
                                              // animator.SetBool("supersalto", false);

            if (Input.GetKeyDown(KeyCode.C) && !agachado && !run)
            {//Si pulso la tecla C y no estoy agachado y no run

                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto));//Accedo a la velocidad del Rigidbody2D y le añado la fuerza vertical establecida en fuerzaSalto
                animator.SetBool("enSuelo", false);//Le digo al animador que no estoy en el suelo
            }

            if (Input.GetKeyDown(KeyCode.C) && !agachado && run)
            {//Si pulso la tecla C y no estoy agachado y run

                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto));//Accedo a la velocidad del Rigidbody2D y le añado la fuerza vertical establecida en fuerzaSalto
                animator.SetBool("enSuelo", false);//Le digo al animador que no estoy en el suelo
            }

        }
        else
        {//Si no estoy en el suelo
            animator.SetBool("enSuelo", false);//Le digo al animador que no estoy en el suelo
        }


        /* if (GoblinGolpeado){
                StartCoroutine(Golpeado());
                GoblinGolpeado = false;

            }*/
        if (GoblimMuerte && estadoGoblin != 2){


            StartCoroutine(Muerte ());
        }
    }



    // FixUpdate is called once 0.02 seconds each frame (This can be modified in edit > Project Settings > Time > Fixed Timestep)
    void FixedUpdate () {

		//MOVIMIENTO HORIZONTAL
		inputX = Input.GetAxis ("Horizontal"); // Almacena el movimiento en el eje X
		//movX = transform.position.x + (inputX * velX);//movX será igual a mi posicion en X + el movimiento en el eje X * velX
		
		if (!agachado && !mirarArriba) {//Si no estoy agachado y no estoy mirando arriba
            transform.position += new Vector3(inputX *velX*Time.deltaTime,0,0);

            //Restingir inicio fin Goblin en nivel
            posIniIFin = Mathf.Clamp(transform.position.x, -9.9f, 85f);
            transform.position = new Vector3(posIniIFin, transform.position.y,0);

			if (inputX > 0) {//Si la velocidad en el eje X es mayor que 0
				//transform.position = new Vector3 (movX, transform.position.y, 0);//mi posicion = movX, la posicion que tenga en y, 0
				transform.localScale = new Vector3 (1, 1, 1);//la escala original si me muevo a la derecha
				//mirandoDerecha = true;//establece que estoy mirando a la derecha
				
			}

			if (inputX < 0) {//Si la velocidad en el eje X es menor que 0
				//transform.position = new Vector3 (movX, transform.position.y, 0);//mi posicion = movX, la posicion que tenga en y, 0
				transform.localScale = new Vector3 (-1, 1, 1);//la escala inversa si me muevo a la izquierda
				//mirandoDerecha = false;//Establece que no estoy mirando a la derecha
				
			}
		}

		if (inputX != 0) {
			animator.SetFloat ("velX", 1);// Si me muevo le digo al animador que la velocidad en X es 1
		} else {
			animator.SetFloat ("velX",0);// Si no me muevo le digo al animador que la velocidad en X es 0
		} 

		//SALTO 

		enSuelo = Physics2D.OverlapCircle (pie.position, radioPie, suelo);// Si estoy tocando el suelo enSuelo será true


		//AGACHARSE

		if (enSuelo && Input.GetKey (KeyCode.DownArrow)) {//Si estoy en el suelo y pulso abajo

			agachado = true;//Establece que estoy agachado
            animator.SetBool("agachado", true);//Le digo al animador que estoy agachado

            //circleP.GetComponent<CircleCollider2D>().enabled = false;  //Borra el collider 
            //modificar radio y posicion del circlecollider
            gameObject.GetComponent<CircleCollider2D>().offset = new Vector2(0f,0.16f);
            gameObject.GetComponent<CircleCollider2D>().radius=0.15f;

           

        } else {
            //circleP.GetComponent<CircleCollider2D>().enabled = true;  //devuelve el collider

            if (Input.GetKeyUp(KeyCode.DownArrow)){ //Volver collider a normal al soltar boton
            
                gameObject.GetComponent<CircleCollider2D>().offset = new Vector2(0.03853655f, 0.2803588f);
                gameObject.GetComponent<CircleCollider2D>().radius = 0.2048309f;
            }

            agachado = false;//Establece que no estoy agachado
			animator.SetBool ("agachado",false);//Le digo al animador que no estoy agachado
            //volver ciclecollider a forma normal

            
        }

        


        //MIRAR ARRIBA
        if (inputX == 0) {//Si no me muevo
			if (enSuelo && Input.GetKey (KeyCode.UpArrow)) {//Si estoy en el suelo y pulso arrba
				mirarArriba = true;//Establece que estoy mirando arriba
				animator.SetBool ("mirarArriba", true);//Le digo al animador que estoy mirando arriba
			} else {
				mirarArriba = false;////Establece que no estoy mirando arriba
				animator.SetBool ("mirarArriba", false);//Le digo al animador que no estoy mirando arriba
			}
		}

		//CAIDA
		caida = rb.velocity.y;//Establezco que caida es igual a la velocidad en el eje y

		if (caida != 0 || caida == 0) {//Tanto si caida es igual o distinta de 0 le paso la velocidad al animador
			animator.SetFloat ("velY",caida);
		}

	

		//CORRER

		if (inputX != 0) {//Si me estoy moviendo

			if (Input.GetKey (KeyCode.X)) {//y pulso X
				run = true;//Establezco que estoy corriendo
				velX = 4f;//Establezco que velX ahora vale 0.06
				animator.SetBool ("run",true);//Le digo al animador que estoy corriendo

			}

            if (!Input.GetKey(KeyCode.X)){//Si me estoy moviendo pero no pulso X
				velX = 2f;//Establezco que velX vale 0.03
				run = false;// Establezco que no estoy corriendo
				animator.SetBool ("run",false);	//Le digo al animador que no estoy corriendo
				
			}

		}else{//Si no me estoy moviendo
			//Reestablezco los valores del código y del animador por defecto
			run = false;
			animator.SetBool ("run",false);
			
		}
        
       /*         //SALTORUN
                if (inputX != 0) {
                //Si me estoy moviendo
                    if (run && Input.GetKeyDown(KeyCode.C))
                    {//Si turbo está activado y pulso C
                        animator.SetBool("enSuelo", false);//Le digo al animador que active saltorun
                    }
                }
                */
                

    }

    /*  public IEnumerator Golpeado()
      {
          for(int i=0; i<=5; i++){
              yield return new WaitForSeconds(0.1f);
              alpha = new Color(1f, 1f, 1f, 0);
              goblinAlpha = goblin.GetComponent <SpriteRenderer>().color = alpha;

              yield return new WaitForSeconds(0.1f);
              alpha = new Color(1f, 1f, 1f, 1);
              goblinAlpha = goblin.GetComponent<SpriteRenderer>().color = alpha;
          }
          StopCoroutine(Golpeado());
      }*/

    public IEnumerator Muerte(){
        //estadoGoblin = 2;
        animator.SetBool("muerte",true);
        velX = 0;

       // rb.isKinematic = true;    //no le afecta la gravedad
        colliderMuertegoblin.isTrigger = true;
        colliderMuertePie.isTrigger = true;
        rb.velocity =    new Vector2(0, 3f);

        yield return new WaitForSeconds(0.2f);

             
        rb.velocity = new Vector2(0, -5f);
        yield return new WaitForSeconds(0.8f);
        //rb.velocity = Vector2.zero;
        //rb.isKinematic = false;//le afecta la gravedad

        //Restablecer goblin inicio
        velX = 2;
        GoblimMuerte = false;
        colliderMuertegoblin.isTrigger = false;
        colliderMuertePie.isTrigger = false;
        transform.position = new Vector3(-9.9f, -4.34191f, 0);
        animator.SetBool("muerte", false);


    }


}
