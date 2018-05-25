using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//needed

public class Controlador2 : MonoBehaviour {

    private string tipoComienzoJuego;
	// Use this for initialization
	void Start () {

        if (GameObject.FindGameObjectWithTag("rondaElegida") != null)
        {
            DestroyObject(GameObject.FindGameObjectWithTag("rondaElegida"));
        }

        if (GameObject.FindGameObjectWithTag("menu2") && GameObject.FindGameObjectWithTag("menu2") != this.gameObject)
        {

            Destroy(GameObject.FindGameObjectWithTag("menu2"));
        }

        if (GameObject.FindGameObjectWithTag("mejorar") != null)
        {
            DestroyObject(GameObject.FindGameObjectWithTag("mejorar"));
        }
        

        tipoComienzoJuego = "";
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CambiarEscena(string nombre)
    {

//        print("cambiando escena" + nombre);
        SceneManager.LoadScene(nombre);

    }
    public void elegirButton()
    {
//        print("vamos a seleccionar nivel");
        SetTipoComienzo("elegir");

    }
    public void nuevaPartida()
    {
        print("vamos a empezar nueva partida");
        SetTipoComienzo("nueva");
    }

    public string GetTipoComienzo()
    {
        return tipoComienzoJuego;
    }

    public void SetTipoComienzo(string str)
    {
        tipoComienzoJuego = str;

    }
    
}
