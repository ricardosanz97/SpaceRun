using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBalasEnemigo : MonoBehaviour
{

    public int velocidad = 5;
    public float tiempoDestruccion = 7f;
    public float danyoBalasEnemigo1 = 5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * velocidad);
        Destroy(gameObject, tiempoDestruccion);
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == ("Player")) {
            collision.GetComponent<MovimientoNave>().vidaNaveEspacial -= danyoBalasEnemigo1;
            GameObject.FindGameObjectWithTag("salud").GetComponent<Salud>().SetVida(danyoBalasEnemigo1 / GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoNave>().getVidaMaximaNave());
            Destroy (gameObject);
			if (collision.GetComponent<MovimientoNave> ().vidaNaveEspacial <= 0) {
				collision.GetComponent<MovimientoNave> ().destruirNave ();
			}
            
        }
		if (collision.tag == ("agujeroNegro")) {
			Destroy (gameObject);
		}
		if (collision.tag == ("escudoActivo")) {
			Destroy (gameObject);
		}
	}
}