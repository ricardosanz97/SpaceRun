using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionadorBola3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemigo")
        {
            print("le hemos dado al enemigo con la bola de fuego. ");
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("BolasGiratorias").GetComponent<girador>().SetUnaBolaMenos();
			GameObject.FindGameObjectWithTag ("guardaResultados").GetComponent<SaveResults> ().SetUnaBolaMenos ();
        }

    }

}
