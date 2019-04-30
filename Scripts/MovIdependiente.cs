using UnityEngine;
using System.Collections;

public class MovIdependiente : MonoBehaviour {

    //ENEMIGO SE MUEVE LIBREMENTE DE PUNTA A PUNTA Y NO CAE

	//VARIABLES RAYCAST
	public GameObject Rayos;
	public GameObject DeteccionCaida;

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
	public bool mirandoDerecha;

	public bool muerte;
	

	public int estado = 0;//0 movimiento  1- Muerte 

	public CircleCollider2D colliderMuerte;

	

	//VARIABLES CODIGO
	Animator animator;
	Rigidbody2D rb;

	void Start () {
		animator = GetComponent <Animator> ();
		rb = GetComponent <Rigidbody2D> ();
		Goblin = GameObject.FindGameObjectWithTag ("goblin");
		Pie = GameObject.FindGameObjectWithTag ("Pie");


	}

	void Update(){
		

		

		//RAYCAST 2D

		//RAYO DERECHA
		InicioRayoDerecha = Rayos.transform.position;
		FinRayoDerecha = new Vector3 (Rayos.transform.position.x + ajusteRaycast, Rayos.transform.position.y, 0);

		RaycastHit2D hitDerecha = Physics2D.Linecast (InicioRayoDerecha, FinRayoDerecha);
		Debug.DrawLine (InicioRayoDerecha, FinRayoDerecha, Color.cyan);

		if(hitDerecha.collider != null){
			if(hitDerecha.collider.gameObject != Goblin){
                //Debug.Log("toca");
               
                CambioDireccion ();
			}

			if(hitDerecha.collider.gameObject.tag == "goblin"){
                //Destroy(Goblin);
            }
		}

		//RAYO IZQUIERDA
		InicioRayoIzquierda = Rayos.transform.position;
		FinRayoIzquerda = new Vector3 (Rayos.transform.position.x - ajusteRaycast, Rayos.transform.position.y, 0);

		RaycastHit2D hitIzquierda = Physics2D.Linecast (InicioRayoIzquierda, FinRayoIzquerda);
		Debug.DrawLine (InicioRayoIzquierda, FinRayoIzquerda, Color.cyan);

		if(hitIzquierda.collider != null){
			if(hitIzquierda.collider.gameObject != Goblin){

				CambioDireccion ();
                //Debug.Log("toca");
            }
           if (hitIzquierda.collider.gameObject.tag == "goblin") {
                //Debug.Log("toca");
               // Destroy(Goblin);
            }
        }

		//RAYO SUPERIOR
		InicioRayoSuperior = Rayos.transform.position;
		FinRayoSuperior = new Vector3 (Rayos.transform.position.x, Rayos.transform.position.y + ajusteRaycast, 0);

		RaycastHit2D hitSuperior = Physics2D.Linecast (InicioRayoSuperior, FinRayoSuperior);
		Debug.DrawLine (InicioRayoSuperior, FinRayoSuperior, Color.cyan);
		if (hitSuperior.collider != null ) {
			if (hitSuperior.collider.gameObject == Pie) {
				
				StartCoroutine(Muerte ());
			}
		}

		//DETECCION CAIDA
		InicioRayoCaida = DeteccionCaida.transform.position;
		FinRayoCaida = new Vector3 (DeteccionCaida.transform.position.x, DeteccionCaida.transform.position.y - ajusteRaycast, 0);

		RaycastHit2D hitCaida = Physics2D.Linecast (InicioRayoCaida, FinRayoCaida);
		Debug.DrawLine (InicioRayoCaida, FinRayoCaida, Color.cyan);

		if(hitCaida.collider == null ){
			CambioDireccion ();
		}
	}

	void FixedUpdate () {

        rb.velocity = new Vector2 (velX, rb.velocity.y);
		
	}

	

	void CambioDireccion(){
		mirandoDerecha = !mirandoDerecha;
		transform.localScale = new Vector3 (transform.localScale.x * -1f, 1f, 1f);
		velX *= -1;
	}


	public IEnumerator Muerte(){
		rb.velocity = Vector2.zero;
		animator.SetBool ("muertePisada",true);
		GetComponent <Collider2D>().isTrigger=true;
		rb.isKinematic = true;
		yield return new WaitForSeconds (2f);
		Destroy (gameObject);
	}


}
