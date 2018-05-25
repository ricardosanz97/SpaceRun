using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitarCamara : MonoBehaviour {

    public Transform heroe;
    public Vector3 desplazamiento;
	// Use this for initialization

	void Start () {	
	}

    // Update is called once per frame

    void Update() {
        var prota = GameObject.Find("NaveEspacialBrillo1");
        if (transform.position.x <= 38.67f && transform.position.x >= -38.67f && transform.position.y <= 18.01f && transform.position.y >= -18.01f) {//camara dentro de los limites
            if (prota != null)
            {
                transform.position = new Vector3(heroe.position.x + desplazamiento.x, heroe.position.y + desplazamiento.y, desplazamiento.z);
            }
            else
            {
                //print("GAME OVER");
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }   
        }
        float nuevaX = Mathf.Clamp(transform.position.x, -38.67f, 38.67f);
        float nuevaY = Mathf.Clamp(transform.position.y, -18.01f, 18.01f);
        transform.position = new Vector3(nuevaX, nuevaY, transform.position.z);
    }
}

