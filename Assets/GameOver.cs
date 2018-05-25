using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Text reachedRounds;
    public Text enemiesKilled;
    public Text bulletsUsed;

    private float round;
    private float enemies;
    private float bullets;

	// Use this for initialization
	void Start () {

        getFinalResults();
        
        /*
        enemigosMuertos = GameObject.FindGameObjectWithTag("Enemigo").GetComponent<Collisionador>().getEnemigosMuertos();
        balasUsadas = GameObject.FindGameObjectWithTag("disparadorNave").GetComponent<Disparador>().getBalasUsadas();
        */

        /*
        reachedRounds.text = "Has alcanzado la ronda " + GameObject.FindGameObjectWithTag("spawnerOleadas").GetComponent<SpawnerOleadas>().getRondaActual();
        bulletsUsed.text = "Has utilizado " + GameObject.FindGameObjectWithTag("disparadorNave").GetComponent<Disparador>().getBalasUsadas();
        enemiesKilled.text = "Has derrotado a " + GameObject.FindGameObjectWithTag("Enemigo").GetComponent<Collisionador>().getEnemigosMuertos() + " enemigos";
        */
    }
	
	// Update is called once per frame
	void Update () {


        


    }

    public void getFinalResults()
    {
        print("tenemos los resultados finales");
        round = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getRound();
        enemies = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getEnemies();
        bullets = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getBullets();
        printFinalResults();


    }
    public void printFinalResults()
    {
        print("printeamos");
        reachedRounds.text = "Has alcanzado la ronda " + round;
        bulletsUsed.text = "Has utilizado " + bullets + " balas";
        enemiesKilled.text = "Has derrotado a " + enemies + " enemigos";

    }
}
