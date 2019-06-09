using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Tipos enumerados para definir las direcciones
public enum DireccionH { Izquierda, Derecha }
public enum DireccionV { Arriba, Abajo }


public class MovPlataforma : MonoBehaviour{

    //MOVIMIENT DE PLATAFORMA EN ZIG ZAG

    // velocidad a la que se moura la plataforma en el eje horizontal.
    public float VelocidadH = 0.3F;

    // Indica el sentit horizontal al que comenzará a movure la plataforma.
    public DireccionH SentidoH = DireccionH.Derecha;

    // Es la velocidad a la que se moura la plataforma en el eje vertical.
    public float VelocidadV = 0.0F;

    // Indica el sentit vertical al que comenzará a moures la plataforma.
    public DireccionV SentidoV = DireccionV.Arriba;

    // Es el la distancia que recorrerá la plataforma en mode ping-pong.
    // Per desactivar el mode ping-pong,la variable a -1.
    public float MaxRecorridoPingPong = 5.0F;

    // Variables privades

    private Transform PlatformTransform;
    private float WalkedDistanceH = 0.0F;
    private float WalkedDistanceV = 0.0F;
    private float ReferencePingPongHPosition;
    private float ReferencePingPongVPosition;
    private Vector3 InitialPlatformPosition;




    // Start is called before the first frame update
    void Start(){

        PlatformTransform = transform;
        InitialPlatformPosition = PlatformTransform.position;
        ReferencePingPongHPosition = PlatformTransform.position.x;
        ReferencePingPongVPosition = PlatformTransform.position.y;

    }

    // Update is called once per frame
    void FixedUpdate(){

        // la distancia horizontal recorreguda desde el últim rebot
        WalkedDistanceH = Mathf.Abs(PlatformTransform.position.x - ReferencePingPongHPosition);

        // la distancia vertical recorreguda desde el últim rebot
        WalkedDistanceV = Mathf.Abs(PlatformTransform.position.y - ReferencePingPongVPosition);

        if (MaxRecorridoPingPong != -1 && WalkedDistanceH >= MaxRecorridoPingPong){

            // Si la funció de Ping-Pong esta activada i  el máximo recorregut en horizontal, la plataforma cambia de sentit

            if (SentidoH == DireccionH.Izquierda) {
                SentidoH = DireccionH.Derecha;
            } else{
                SentidoH = DireccionH.Izquierda;
            }

            // Actualizar la posició horizontal de referencia para el  (ping-pong)
            ReferencePingPongHPosition = PlatformTransform.position.x;
        }

        if (MaxRecorridoPingPong != -1 && WalkedDistanceV >= MaxRecorridoPingPong) {
            // Si la funció de Ping-Pong está activada i el máxim recorrido en vertical, la plataforma cambia de sentit
            if (SentidoV == DireccionV.Arriba){

                SentidoV = DireccionV.Abajo;
            }else{
                SentidoV = DireccionV.Arriba;
            }

            // Actualizar la posicio vertical de referencia para el calcul (ping-pong)
            ReferencePingPongVPosition = PlatformTransform.position.y;
        }

        // Configurem el sentit del movimient horizontal

        if (SentidoH == DireccionH.Izquierda) {
            VelocidadH = -Mathf.Abs(VelocidadH);
        } else{
            VelocidadH = Mathf.Abs(VelocidadH);
        }

        // Configurem el sentit del movimient vertical
        if (SentidoV == DireccionV.Abajo){
            VelocidadV = -Mathf.Abs(VelocidadV);
        }else{
            VelocidadV = Mathf.Abs(VelocidadV);
        }

        // Movere la plataforma
        PlatformTransform.Translate(new Vector3(VelocidadH, VelocidadV, 0) * Time.deltaTime);


     
    }




    void OnTriggerStay2D(Collider2D other){
    
        if (other.gameObject.tag == "goblin" || other.gameObject.tag == "pie"){
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
      
        if (other.gameObject.tag == "goblin"){

            other.transform.parent = null;

            if(other.gameObject.tag == "pie") {
                other.transform.parent = transform;
            }
        }
    }

   
}
