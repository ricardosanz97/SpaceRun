using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//needed

public class Controlador : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if (GameObject.FindGameObjectWithTag("guardaResultados") != null)
        {
            DestroyObject(GameObject.FindGameObjectWithTag("guardaResultados"));
        }
        if (GameObject.FindGameObjectWithTag("menu2") != null)
        {
            DestroyObject(GameObject.FindGameObjectWithTag("menu2"));
        }
        if (GameObject.FindGameObjectWithTag("rondaElegida") != null)
        {
            DestroyObject(GameObject.FindGameObjectWithTag("rondaElegida"));
        }
	}
	
	// Update is called once per frame
	void Update () {
		



	}

    public void CambiarEscena(string nombre)
    {
        
//        print("cambiando escena" + nombre);
        SceneManager.LoadScene(nombre);

    }
    public void Salir()
    {
        print("saliendo del juego");
        Application.Quit();
    }
}
