using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public GameObject gamecontroler;
    public bool muerto;
    int vida;


    public void controlvidas()
    {

        if (vida == 0)
        {
            muerto = true;
        }
        else
        {
            muerto = false;
        }
    }
}
