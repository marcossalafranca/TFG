using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
   public void BotonJugar(){
        SceneManager.LoadScene("1");
    }

    public void BotonSalir()
    {
        Application.Quit();
    }

    public void BotonInicio()
    {
        SceneManager.LoadScene("Scenes/Main");
    }
    public void BotonSegonNivell()
    {
        SceneManager.LoadScene("2");
    }

    public void Botonnivellguardat()
    {
        SceneManager.LoadScene("nivell guardado ultimo");
    }
}
