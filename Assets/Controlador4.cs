using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//needed

public class Controlador4 : MonoBehaviour {
    private bool vengoDeMejorarBool;

    public void CambiarEscena(string nombre)
    {

        //print("cambiando escena" + nombre);
        SceneManager.LoadScene(nombre);

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void vengoDeMejorar()
    {

        vengoDeMejorarBool = true;

    }
    public bool getVengoDeMejorar()
    {
        return vengoDeMejorarBool;

    }

	public void setVengoDeMejorar(bool value){

		vengoDeMejorarBool = value;
	}
}
