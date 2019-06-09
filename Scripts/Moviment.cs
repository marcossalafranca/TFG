using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Moviment : MonoBehaviour {

    //Variables reinici
    public GameObject enemigos;
    public GameObject check;
    public GameManager gm;

    public GameObject goblin;
    public int nivell ;

    //variables mort
    public GameObject control;
    public bool gameover = false;
   



    //VARIABLES MOVIEMIENT
    public float velX;
    float inputX;
    float posIniIFin;

    public bool mirandoDerecha;

	//VARIABLES DE SALT
	public float fuerzaSalto;
	public Transform pie;
	public float radioPie = 0.08f;
	public LayerMask suelo;
	public bool enSuelo;
    private bool jump;

	//VARIABLES AJUPIT
	public bool agachado;
   

    //VARIABLES MIRAR AMUNT
    public bool mirarArriba; 

	//VARIABLES CAIGUDA
	public float caida;
	Rigidbody2D rb;

	//VARIABLES CORRER
	public bool run;

    //checkpoint
    public bool checkpoint;

    //ANIMACIONS
    private SpriteRenderer spr;

    Animator animator;

    //SO

    public AudioClip audiosalto;
    public AudioClip audioMuerte;

    AudioSource sonido;
    AudioSource audioGoblin;



    void Awake(){

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        gm = FindObjectOfType<GameManager>();
        
        audioGoblin = GetComponent<AudioSource>();

    }
  
    //VARIABLE MUERTE
    public CircleCollider2D colliderMuertegoblin;
    public CircleCollider2D colliderMuertePie;
    
    public bool GoblimMuerte;
    public int estadoGoblin;

    // Use this for initialization
    
    void Update() {

        

        //SALTO    Ficat aqui para que no doni errors al saltar
        if (enSuelo){  //Si estic en el suelo

            animator.SetBool("enSuelo", true);//al animador que estic en el suelo
  
            if ((Input.GetKeyDown(KeyCode.C)) && !agachado && !run ){    //Si trepitxo la tecla C y no estic ajupit i no run
                if (gm.GetComponent<Botons>().fxOn == false) {
                    audioGoblin.clip = audiosalto;
                    audioGoblin.Play();
                }

                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto));//Accedir a la velocidad del Rigidbody2D i  incloure la fuerza vertical de  fuerzaSalto
                animator.SetBool("enSuelo", false);//al animador que no estic en el suelo
            }

           if ((Input.GetKeyDown(KeyCode.C) ) && !agachado && run){    //Si trepitxo la tecla C y no estic ajupit i run
                if (gm.GetComponent<Botons>().fxOn == false){
                    audioGoblin.clip = audiosalto;
                    audioGoblin.Play();
                }

                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto));
                animator.SetBool("enSuelo", false);
            }

        }else {//Si no estic en el suelo

            animator.SetBool("enSuelo", false);
        }


        if (GoblimMuerte && estadoGoblin != 2){

            StartCoroutine(Muerte ());
        }

    }


    void FixedUpdate () {

		//MOVIMIENT HORIZONTAL


		inputX = Input.GetAxis ("Horizontal"); // Enmagatgemar  el movimient en el eje X
		
		
		if (!agachado && !mirarArriba) {
            transform.position += new Vector3(inputX *velX*Time.deltaTime,0,0);

            //Restingir inici fi Goblin en nivell

            posIniIFin = Mathf.Clamp(transform.position.x, -14.32f, 205f);
            transform.position = new Vector3(posIniIFin, transform.position.y,0);

			if (inputX > 0) {//Si la velocidad en el eix X es major que 0
				
				transform.localScale = new Vector3 (1, 1, 1); //la escala original si me vaig cap a la dreta
		
			}

			if (inputX < 0) {//Si la velocidad en el eix X es menor que 0
				
				transform.localScale = new Vector3 (-1, 1, 1);//la escala inversa si vaig  a la esquerra

			}
		}

		if (inputX != 0) {
			animator.SetFloat ("velX", 1);// Si es mou el goblin al animador que la velocidad en X es 1
		} else {
			animator.SetFloat ("velX",0);// Si no es mou el goblin al animador que la velocidad en X es 0
		} 

		//SALT 

		enSuelo = Physics2D.OverlapCircle (pie.position, radioPie, suelo);   


		//AJUPINT-SE

		if (enSuelo && ( Input.GetKey (KeyCode.DownArrow))){//Si estic en el suelo y pulse baix

			agachado = true;//estar agachado
            animator.SetBool("agachado", true);//al animador que estic agachado

            //Modificar collider per estar ajupit

            gameObject.GetComponent<CircleCollider2D>().offset = new Vector2(0f,0.16f);
            gameObject.GetComponent<CircleCollider2D>().radius=0.15f;

        } else {
            
            if (Input.GetKeyUp(KeyCode.DownArrow)){ // collider a normal al soltar boto
            
                gameObject.GetComponent<CircleCollider2D>().offset = new Vector2(0.03853655f, 0.2803588f);
                gameObject.GetComponent<CircleCollider2D>().radius = 0.2048309f;
            }

            agachado = false;
			animator.SetBool ("agachado",false);
  
        }


        //MIRAR AMUNT
        if (inputX == 0) {//Si estic parat

			if (enSuelo && (Input.GetKey (KeyCode.UpArrow) )) {//Si estic en el suelo y pulso dalt
				mirarArriba = true;
				animator.SetBool ("mirarArriba", true);// al animador que estic mirant amunt
			} else {
				mirarArriba = false;
				animator.SetBool ("mirarArriba", false);
			}
		}

		//CAIGUDA

		caida = rb.velocity.y;// caida es igual a la velocidat en el eix y

		if (caida != 0 || caida == 0) {//Tant si caida es igual o distint de 0 se li pasa la velocidat al animador
			animator.SetFloat ("velY",caida);
		}

	

		//CORRER

		if (inputX != 0) {//Si me estic movent

			if ( Input.GetKey (KeyCode.X) ) {// pulso X
            
				run = true;// corrent
				velX = 4f;// velX ahora vale 4
				animator.SetBool ("run",true);

			}
        

          if (!Input.GetKey(KeyCode.X) ) {// no pulso X

               velX = 2f;
               run = false;
               animator.SetBool ("run",false); 
             
           }

    }else{//Si no me estic movent
			//Reinicirar  los valors del códic y del animador por defecte
			run = false;
			animator.SetBool ("run",false);
			
		}
    

    }



    public IEnumerator Muerte(){

        animator.SetBool("muerte",true);
        velX = 0;

        colliderMuertegoblin.isTrigger = true;
        colliderMuertePie.isTrigger = true;
        rb.velocity =    new Vector2(0, 3f);

        yield return new WaitForSeconds(0.2f);

             
        rb.velocity = new Vector2(0, -5f);
        yield return new WaitForSeconds(0.8f);

        gameover = control.GetComponent<GameManager>().muerto;
      
        if (gameover==false) { // mentres tinga vides vides
            //reinici goblin 
           
            velX = 2;
            GoblimMuerte = false;
            colliderMuertegoblin.isTrigger = false;
            colliderMuertePie.isTrigger = false;
            gm.tiempoActuales = 300;

            if (nivell == 1) {
                if (check.GetComponent<Checkpoint>().checkpoint == true){

                    transform.position = new Vector3(49.08f, -4.341914f, 0);
                    animator.SetBool("muerte", false);
                    enemigos.GetComponent<RestaurarEnemigos>().Reactivar();

                } else{   // anar al punt de control si ha pasat

                    transform.position = new Vector3(-11.32f, -4.341914f, 0);
                    animator.SetBool("muerte", false);
                    enemigos.GetComponent<RestaurarEnemigos>().Reactivar();// crida a la funcio del script restaurearenemigo
                                                                           // de  la clase del gameobject enemic

                }
            }

            if (nivell == 2){
                if (check.GetComponent<Checkpoint>().checkpoint2 == true){

                    transform.position = new Vector3(87.75f,-4.34f, 0);
                    animator.SetBool("muerte", false);
                    enemigos.GetComponent<RestaurarEnemigos2>().Reactivar();

                }else {   // anar al punt de control si ha pasat

                    transform.position = new Vector3(-6.3f, -4.34f, 0);
                    animator.SetBool("muerte", false);
                    enemigos.GetComponent<RestaurarEnemigos2>().Reactivar();

                  
                }

            }


            if (nivell == 3) {
                if (check.GetComponent<Checkpoint>().checkpoint3 == true){

                    transform.position = new Vector3(83.28f, -2.41f, 0);
                    animator.SetBool("muerte", false);
                    enemigos.GetComponent<RestaurarEnemigos3>().Reactivar();

                } else {   // anar al punt de control si ha pasat

                    transform.position = new Vector3(-7.32f, -4.363544f, 0);
                    animator.SetBool("muerte", false);
                    enemigos.GetComponent<RestaurarEnemigos3>().Reactivar();
                
                }
            }
        }
      

    }


}
