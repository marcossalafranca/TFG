using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fake : MonoBehaviour{

    public RectTransform fadeSize;
    public Image fade;

    float alpha = 0;
    float fadeSpeed = 2.5f;
    bool fading;

    GameManager manager;
   void Awake(){
        manager = FindObjectOfType<GameManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        fadeSize.sizeDelta = new Vector2(Screen.width, Screen.height);
        alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fade.color=new Color(1,1,1,alpha);
        if (fading)
        {
            FadeOut();
        }

    }
    public void FadeIn()
    {
        alpha += fadeSpeed * Time.deltaTime;

        if(alpha >= 1)
        {
           // manager.cargarPantalla();  carga el siguiente nivell
            fading = true;
        }
    }

    public void FadeOut()
    {
        alpha -= fadeSpeed * Time.deltaTime;
        if (alpha <= 0)
        {
            alpha = 0;
            fading = false;
        }
    }
}
