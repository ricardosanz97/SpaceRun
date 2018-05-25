using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoverBalas : MonoBehaviour
{
    public int velocidad = 5;
    public float tiempoDestruccion = 2f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * velocidad);
        Destroy(gameObject, tiempoDestruccion);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == ("Enemigo"))
        {
            Destroy(gameObject);
        }
        if (collision.tag == ("agujeroNegro"))
        {
            Destroy(gameObject);
        }
    }
}















