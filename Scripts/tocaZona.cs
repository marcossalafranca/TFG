using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tocaZona : MonoBehaviour
{


    public GameObject bolaposicion;
    public GameObject bala;
    GameObject clone;
        public float velocidad;


    float disparoCuenta;
    public float tiempoDisparo;
    public float balalife;
        


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            bala.transform.Translate(-velocidad * Time.deltaTime, 0, 0);


        disparoCuenta += Time.deltaTime;

        if (disparoCuenta >= tiempoDisparo)
        {
            clone= Instantiate(bala, bolaposicion.transform.position, bala.transform.rotation) ;
            disparoCuenta = 0;
        }
        
       Destroy(clone, balalife);

    }
     //   void OnTriggerEnter(Collider otro)
    //    {
            
          //  Destroy(this.gameObject);
      //  }
    
}
