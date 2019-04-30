using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject Goblin;
    
    public bool checkpoint;

    // Start is called before the first frame update
    void Start(){
        Goblin = GameObject.FindGameObjectWithTag("goblin");
    }

    void OnTriggerEnter2D(Collider2D collision) {
  
        if (collision.gameObject== Goblin){
            this.checkpoint = true;
        }

    }
}
