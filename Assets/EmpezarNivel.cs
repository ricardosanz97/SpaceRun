using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EmpezarNivel : MonoBehaviour {

    public bool juegoIniciado = false;
    public bool mostrarTextoInicio = true;
    public Canvas preStartCanvas;
    //public Canvas waveInfoCanvas;

	// Use this for initialization
	void Start () {

        //juegoIniciado = false;
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Apuntado>().inPause = true;
        preStartCanvas.gameObject.SetActive(true);
        //waveInfoCanvas.gameObject.SetActive(true);
        


    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
        {
            juegoIniciado = true;
            preStartCanvas.gameObject.SetActive(false);
            //waveInfoCanvas.gameObject.SetActive(false);
            mostrarTextoInicio = false;
        }
        if (juegoIniciado)
        {
            Time.timeScale = 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Apuntado>().inPause = false;
            

        }
        else if (!juegoIniciado)
        {
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Apuntado>().inPause = true;
            //waveInfoCanvas.gameObject.SetActive(true);
            //preStartCanvas.gameObject.SetActive(true);

        }
        if (mostrarTextoInicio)
        {
            preStartCanvas.gameObject.SetActive(true);

        }
        else if (!mostrarTextoInicio)
        {
            preStartCanvas.gameObject.SetActive(false);
        }
	}
}
