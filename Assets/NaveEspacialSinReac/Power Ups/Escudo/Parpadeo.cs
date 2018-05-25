using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parpadeo : MonoBehaviour {
    public bool activarEscudo = false;
    public Light luzParpadeando;
    private bool aumentar;
    public float duracionActivacion;
    //private float contador = 0;
	// Use this for initialization
	void Start ()
    {	
	}
	// Update is called once per frame
	void Update ()
    {
        GameObject navePrincipal = GameObject.Find("NaveEspacialBrillo1");
        GameObject escudino = GameObject.Find("NaveConEscudo1");
        bool estaActivado = navePrincipal.GetComponent<MovimientoNave>().escudoActivado;
        if (activarEscudo)//el parpadeo
        {
            if (luzParpadeando.intensity > 0.6f)
            {
                aumentar = false;
            }
            else if (luzParpadeando.intensity == 0)
            {
                aumentar = true;
            }

            if (aumentar)
            {
                luzParpadeando.intensity += 0.01f;
            }
            else
            {
                luzParpadeando.intensity -= 0.01f;
            }
        }  
	}
}
