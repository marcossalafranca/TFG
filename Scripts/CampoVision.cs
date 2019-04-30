using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoVision : MonoBehaviour
{
    public bool veo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goblin")
        {
            veo = true;
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Goblin")
        {
            veo = false;
        }
    }

}
