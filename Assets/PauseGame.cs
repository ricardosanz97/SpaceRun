using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseGame : MonoBehaviour {
    public Canvas canvas;
    //public Canvas canvas2;
    //public Transform Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();


        }

        

	}

    public void Pause()
    {
        //print("clicando boton");
        if (canvas.gameObject.activeInHierarchy == false)
        {

            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Apuntado>().inPause = true;
            //GameObject.FindGameObjectWithTag("botonContinuar").active = true;
            GameObject.FindGameObjectWithTag("controlador").GetComponent<EmpezarNivel>().juegoIniciado = false;

        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            
            GameObject.FindGameObjectWithTag("Player").GetComponent<Apuntado>().inPause = false;
            GameObject.FindGameObjectWithTag("controlador").GetComponent<EmpezarNivel>().juegoIniciado = true;
            //GameObject.FindGameObjectWithTag("botonContinuar").active = false;
        }


    }
    public void clickContinue()
    {
        print("boton clickado");
        Time.timeScale = 1;
        canvas.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Apuntado>().inPause = false;

    }
}
