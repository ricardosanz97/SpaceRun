using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NavegadorEscenas : MonoBehaviour {
    //public bool botonPulsado = false;
    public float balasTotales;
    public float enemigosAbatidos;
    public float rondaActual;

    public bool pulsado;
    public Vector3 posicion;
	// Use this for initialization
	void Start () {
        
        //DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {


    }

    public void CambiarEscena(string nombre)
    {

        print("cambiando escena" + nombre);
        SceneManager.LoadScene(nombre);

    }

    public void guardaPuntuacionesActuales()
    {
        balasTotales = GameObject.FindGameObjectWithTag("disparadorNave").GetComponent<Disparador>().getBalasUsadas();
        enemigosAbatidos = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoNave>().getEnemigosAbatidos();
        rondaActual = GameObject.FindGameObjectWithTag("spawnerOleadas").GetComponent<SpawnerOleadas>().getRondaActual();

        posicion = GameObject.FindGameObjectWithTag("Player").transform.position;
        acumulamosResultados();


    }
    public void hePulsadoElBotonMiNave()
    {
        
        GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().botonMiNavePulsado = true;
        //print("se ha pulsado el boton mi nave");
        //print(GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().botonMiNavePulsado);

        //guardaPuntuacionesActuales();
        //pulsado = true;
       

    }

    public void acumulamosResultados()
    {
        GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().setEnemies(GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getEnemies() + enemigosAbatidos);
        print("llevamos " + GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getEnemies() + " enemigos abatidos");
        GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().setBullets(GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getBullets() + balasTotales);
        print("llevamos " + GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getBullets() + " balas utilizadas");

    }
    
}
