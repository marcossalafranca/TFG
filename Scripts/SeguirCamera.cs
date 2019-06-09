using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeguirCamera : MonoBehaviour{
    
    public GameObject seguir;
    public Vector2 minCamPos, MaxCamPos;
    public float smoothTime;
   
    private Vector2 velocidad;

  
 
    // Update is called once per frame
    void FixedUpdate(){//suavizar camara movimiento

        float posX = Mathf.SmoothDamp(transform.position.x, 
        seguir.transform.position.x, ref velocidad.x, smoothTime); 
        float posy = Mathf.SmoothDamp(transform.position.y,
        seguir.transform.position.y, ref velocidad.y, smoothTime);


        transform.position = new Vector3(
        Mathf.Clamp(posX,minCamPos.x, MaxCamPos.x),
        Mathf.Clamp(posy, minCamPos.y, MaxCamPos.y),
        transform.position.z);
    }
}
