using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//needed

public class Controlador3 : MonoBehaviour {

    private float rondaElegida;
	// Use this for initialization
	void Start () {

        DontDestroyOnLoad(this.gameObject);
        rondaElegida = -1f;
	}
	
	// Update is called once per frame
	void Update () {

        

	}
    public void CambiarEscena(string nombre)
    {

//        print("cambiando escena" + nombre);
        SceneManager.LoadScene(nombre);

    }
    
    public void Pulsado5()
    {
        SetRondaElegida(5f);


    }
    public void Pulsado10()
    {
        SetRondaElegida(10f);


    }
    public void Pulsado15()
    {
        SetRondaElegida(15f);


    }
    public void Pulsado20()
    {
        SetRondaElegida(20f);

    }

    public float GetRondaElegida()
    {
        return rondaElegida;

    }
    public void SetRondaElegida(float value)
    {
        rondaElegida = value;
    }

}
