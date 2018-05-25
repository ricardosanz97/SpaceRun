using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movAgujeroNegro : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            float nuevaX = Random.Range(-55, 55);
            float nuevaY = Random.Range(-27, 27);
            Vector3 nuevaPos = new Vector3(nuevaX, nuevaY, -10);
            transform.position = nuevaPos;
        }
    }
}
