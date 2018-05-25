using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Collisionador : MonoBehaviour {
    private int numBalasParaSerDestruido;
    private int contador = 0;
    public float danyoExplosionNavePrincipal = 20f;


    //private float contadorEnemigosMuertos = 0f;
    
    // Use this for initialization
    void Start () {

        numBalasParaSerDestruido = GameObject.FindGameObjectWithTag("spawnerOleadas").GetComponent<SpawnerOleadas>().getBalasDestruirEnemigo();


        //print(numBalasParaSerDestruido);


        //numBalasParaSerDestruido = GameObject.FindGameObjectWithTag("controlador").GetComponent<SpawnerOleadas>.Oleadas
        //DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {

        if (contador >= numBalasParaSerDestruido)
        {
            destruirEnemigo1();
            
        }
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "BalasNave")
        {
            contador++;
        }

        if (collision.tag == "agujeroNegro")
        {
            float nuevaX = Random.Range(-55, 55);
            float nuevaY = Random.Range(-27, 27);
            Vector3 nuevaPos = new Vector3(nuevaX, nuevaY, -10);
            transform.position = nuevaPos;
        }

        if (collision.tag == "escudoActivo")
        {
            destruirEnemigo1();
        }

        

    }
    public void destruirEnemigo1()
    {

        GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoNave>().enemigosAbatidos++;
        GameObject.FindGameObjectWithTag("spawnerOleadas").GetComponent<SpawnerOleadas>().enemiesLeft--;
        Destroy(gameObject);
    }
    
}
