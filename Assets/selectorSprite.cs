using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectorSprite : MonoBehaviour {
    public Sprite spriteEscudo;
    public Sprite spriteGirador;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update()
    {
        /*
        if (GameObject.Find("GameController").GetComponent<SpawnPowerups>().powerupsActivos[0] == false && GameObject.Find("GameController").GetComponent<SpawnPowerups>().powerupsActivos[1] == false)
        {
            this.GetComponent<SpriteRenderer>().sprite = null;
        }
        else if (GameObject.Find("GameController").GetComponent<SpawnPowerups>().powerupsActivos[0] == false && GameObject.Find("GameController").GetComponent<SpawnPowerups>().powerupsActivos[1] == true)
        {
            this.GetComponent<SpriteRenderer>().sprite = spriteGirador;
        }
        else if (GameObject.Find("GameController").GetComponent<SpawnPowerups>().powerupsActivos[0] == true && GameObject.Find("GameController").GetComponent<SpawnPowerups>().powerupsActivos[1] == false)
        {
            this.GetComponent<SpriteRenderer>().sprite = spriteEscudo;
        }
        */
    }    
}
