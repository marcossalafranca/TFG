using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadaMov : MonoBehaviour
 {
    // MOVIMIENTO ENEMIGO ENTRE DOS DISTANCIAS


public float posicitonInicial;
public float velEnemigo = 1;
public float movimiento = 1f;
public bool mirandoDerecha;


public float velX = 1;


Animator animator;
Rigidbody2D rb;

// Start is called before the first frame update
void Start()
{
    animator = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    posicitonInicial = this.transform.position.x;
    
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
    animator.SetBool("muertePisada", true);
    GetComponent<Collider2D>().isTrigger = true;
    rb.isKinematic = true;
    yield return new WaitForSeconds(1.5f);
    //Destroy(gameObject);
    gameObject.SetActive(false);
    velEnemigo = 1;
   


}
   
}
