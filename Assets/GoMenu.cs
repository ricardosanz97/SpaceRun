using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//needed

public class GoMenu : MonoBehaviour {

    public void CambiarEscena(string nombre)
    {

        print("cambiando escena" + nombre);
        SceneManager.LoadScene(nombre);

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
