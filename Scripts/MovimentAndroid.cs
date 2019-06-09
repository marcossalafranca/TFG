using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MovimentAndroid : MonoBehaviour {

    //Variables reinici
    public GameObject enemigos;
    public RestaurarEnemigos dbcnx;
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



    void Awake()
    {
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

   
    void Update() {

        
        //salt
        if (enSuelo)
        {

            animator.SetBool("enSuelo", true);

            if ((Input.GetKeyDown(KeyCode.C)||Input.GetButtonDown("Jump") ) && !agachado && !run )
            {
                if (gm.GetComponent<Botones>().fxOn == false)
                {
                    audioGoblin.clip = audiosalto;
                    audioGoblin.Play();
                }
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto));
                animator.SetBool("enSuelo", false);
            }

           if ((Input.GetKeyDown(KeyCode.C) ) && !agachado && run)
            {
                if (gm.GetComponent<Botones>().fxOn == false)
                {
                    audioGoblin.clip = audiosalto;
                    audioGoblin.Play();
                }
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto));
                animator.SetBool("enSuelo", false);
            }

        }
        else
        {
            animator.SetBool("enSuelo", false);
        }


   
        if (GoblimMuerte && estadoGoblin != 2){


            StartCoroutine(Muerte ());
        }
    }



    // FixUpdate is called once 0.02 seconds each frame (This can be modified in edit > Project Settings > Time > Fixed Timestep)
    void FixedUpdate () {

		//MOVIMIENT HORIZONTAL
		inputX = Input.GetAxis ("Horizontal"); 
	
		
		if (!agachado && !mirarArriba) {
            transform.position += new Vector3(inputX *velX*Time.deltaTime,0,0);

       
            posIniIFin = Mathf.Clamp(transform.position.x, -14.32f, 205f);
            transform.position = new Vector3(posIniIFin, transform.position.y,0);

			if (inputX > 0) {
				
				transform.localScale = new Vector3 (1, 1, 1);
			
				
			}

			if (inputX < 0) {
				
				transform.localScale = new Vector3 (-1, 1, 1);
				
				
			}
		}

		if (inputX != 0) {
			animator.SetFloat ("velX", 1);
		} else {
			animator.SetFloat ("velX",0);
		} 

		//SALT

		enSuelo = Physics2D.OverlapCircle (pie.position, radioPie, suelo);


		//AJUPITSE

		if (enSuelo && ( Input.GetKey (KeyCode.DownArrow) ||  Input.GetButton ("Vertical")))
        {

			agachado = true;
            animator.SetBool("agachado", true);

        
            gameObject.GetComponent<CircleCollider2D>().offset = new Vector2(0f,0.16f);
            gameObject.GetComponent<CircleCollider2D>().radius=0.15f;

           

        } else {
           
            gameObject.GetComponent<CircleCollider2D>().offset = new Vector2(0.03853655f, 0.2803588f);
            gameObject.GetComponent<CircleCollider2D>().radius = 0.2048309f;
            if (Input.GetKeyUp(KeyCode.DownArrow))
            { 
            
                gameObject.GetComponent<CircleCollider2D>().offset = new Vector2(0.03853655f, 0.2803588f);
                gameObject.GetComponent<CircleCollider2D>().radius = 0.2048309f;
            }

            agachado = false;
			animator.SetBool ("agachado",false);
          

            
        }

        


        //MIRAR AMUNT
        if (inputX == 0) {//Si no me muevo
			if (enSuelo && (Input.GetKey (KeyCode.UpArrow) || Input.GetButton("Fire3"))) {
				mirarArriba = true;
				animator.SetBool ("mirarArriba", true);
			} else {
				mirarArriba = false;
				animator.SetBool ("mirarArriba", false);
			}
		}

		//CAIGUDA
		caida = rb.velocity.y;

		if (caida != 0 || caida == 0) {
			animator.SetFloat ("velY",caida);
		}

	

		//CORRER

		if (inputX != 0) {

			if ( Input.GetKey (KeyCode.X) || Input.GetButton("Fire2")) {
          
				run = true;
				velX = 0f;
				animator.SetBool ("run",true);

			}
        

          if (!Input.GetKey(KeyCode.X) || !Input.GetButton("Fire2"))     
           {
               velX = 4f;
               run = false;
               animator.SetBool ("run",false); 
              
           }

    }else{
			
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
      
        if (gameover==false) { 
         
           
            velX = 2;
            GoblimMuerte = false;
            colliderMuertegoblin.isTrigger = false;
            colliderMuertePie.isTrigger = false;
            gm.tiempoActuales = 300;

            if (nivell == 1)
            {
                if (check.GetComponent<Checkpoint>().checkpoint == true)
                {

                    transform.position = new Vector3(49.08f, -4.341914f, 0);
                    animator.SetBool("muerte", false);
                    enemigos.GetComponent<RestaurarEnemigos>().Reactivar();

                }
                else
                {   
                    transform.position = new Vector3(-11.32f, -4.341914f, 0);
                    animator.SetBool("muerte", false);
                    enemigos.GetComponent<RestaurarEnemigos>().Reactivar();
                   
                }
            }

            if (nivell == 2)
            {
                if (check.GetComponent<Checkpoint>().checkpoint2 == true)
                {

                    transform.position = new Vector3(87.75f,-4.34f, 0);
                    animator.SetBool("muerte", false);
                    enemigos.GetComponent<RestaurarEnemigos2>().Reactivar();

                }
                else
                {  

                    transform.position = new Vector3(-6.3f, -4.34f, 0);
                    animator.SetBool("muerte", false);
                    enemigos.GetComponent<RestaurarEnemigos2>().Reactivar();

                }

            }


            if (nivell == 3)
               
            {
                if (check.GetComponent<Checkpoint>().checkpoint3 == true)
                {

                    transform.position = new Vector3(83.28f, -2.41f, 0);
                    animator.SetBool("muerte", false);
                    enemigos.GetComponent<RestaurarEnemigos3>().Reactivar();

                }
                else
                {   

                    transform.position = new Vector3(-7.32f, -4.363544f, 0);
                    animator.SetBool("muerte", false);
                    enemigos.GetComponent<RestaurarEnemigos3>().Reactivar();

                }
            }
        }
      

    }


}
