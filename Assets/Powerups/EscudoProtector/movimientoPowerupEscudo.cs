using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPowerupEscudo : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if (GameObject.Find("GameController").GetComponent<SpawnPowerups>().nuevoSpawneoEscudo == true)
        {
            float nuevaX = Random.Range(-55, 55);
            float nuevaY = Random.Range(-27, 27);
            Vector3 nuevaPos = new Vector3(nuevaX, nuevaY, -10);
            transform.position = nuevaPos;
            GameObject.Find("GameController").GetComponent<SpawnPowerups>().nuevoSpawneoEscudo = false;
        }
        */
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            if (GameObject.Find("GameController").GetComponent<SpawnPowerups>().giradorActivado == true)
            {

                GameObject.Find("GameController").GetComponent<SpawnPowerups>().activarEscudo();
                GameObject.Find("GameController").GetComponent<SpawnPowerups>().contador = 0f;


                

            }
            if (GameObject.Find("GameController").GetComponent<SpawnPowerups>().giradorActivado == false)
            {
                GameObject.Find("GameController").GetComponent<SpawnPowerups>().activarEscudo();
                GameObject.Find("GameController").GetComponent<SpawnPowerups>().contador = 0f ;


            }
           
            Destroy(gameObject);

        }
    }
}
