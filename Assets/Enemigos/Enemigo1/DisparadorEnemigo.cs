using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorEnemigo : MonoBehaviour {

    public float permiso = 0;
    public float danyo = 10;
    float tiempoDisparo = 0;

    Transform puntoDisparo;
    Transform puntoDisparoIzdo;

    public GameObject Bullet;

    // Use this for initialization
    void Start()
    {
      
        puntoDisparo = transform.Find("FirePointEnemigo");
        puntoDisparoIzdo = transform.Find("FirePointEnemigoIzdo");
        if (puntoDisparo == null || puntoDisparoIzdo == null)
        {
            Debug.LogError("No firepoint");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float rand = Random.Range(0, 100);
        if (permiso == 0)
        {
            Disparar();
        }
        else
        {
            if (Time.time > tiempoDisparo && (rand == 69 || rand == 25))
            {
                tiempoDisparo = Time.time + 1 / permiso;
                Disparar();
            }
        }
    }
    void Disparar()
    { 
        Vector2 firePointPosition = new Vector2(puntoDisparo.position.x, puntoDisparo.position.y);
        Vector2 firePointPosition2 = new Vector2(puntoDisparoIzdo.position.x, puntoDisparoIzdo.position.y);
        Effect();
    }
    void Effect()
    {

        Instantiate(Bullet, puntoDisparo.position, puntoDisparo.rotation);
        Instantiate(Bullet, puntoDisparoIzdo.position, puntoDisparoIzdo.rotation);
    }
}
