using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveResults : MonoBehaviour {
    public bool botonMiNavePulsado = false;

    private float round;
    private float enemies;
    private float bullets;

    private float vidaMaxima;
    private float staminaMaxima;
    private float cadenciaMaxima;

    private float puntosPorUtilizar;



    private float currentLifePoints;
    private float currentStaminaPoints;
    private float currentRatioPoints;

    public float currentRound;

    private float currentLife;
    private float currentDefeatedEnemies;
    private float currentStamina;
    public Vector3 currentPosition;
    public Vector3 escudoPosition;
    public Vector3 agujeroNegroPosition;
    public Vector3 giradorPosition;

    private Quaternion currentRotation;


    public Vector3 posicionVerdaderaEscudo;
    public Vector3 posicionVerdaderaGirador;
    public Vector3 posicionVerdaderaAgujero;

    public float currentCounterShield;
	public float currentCounterFireBalls;
    public bool shieldOnActive;
	public bool fireBallsOnActive;

    public Vector3 guardarPosicionVerdaderaEscudo;
    public Vector3 guardarPosicionVerdaderaGirador;
    public Vector3 guardarPosicionVerdaderaAgujero;

	private float bolasRestantes;
	// Use this for initialization
	void Start () {

        print("la posicion vale " + posicionVerdaderaEscudo);
       

        /*
        if (GameObject.FindGameObjectWithTag("controlador").GetComponent<NavegadorEscenas>().pulsado)
        {

            enemies = GameObject.FindGameObjectWithTag("controlador").GetComponent<NavegadorEscenas>().enemigosAbatidos;
            bullets = GameObject.FindGameObjectWithTag("controlador").GetComponent<NavegadorEscenas>().balasTotales;

            GameObject.FindGameObjectWithTag("controlador").GetComponent<NavegadorEscenas>().pulsado = false;


        }
        */
        /*
        if (posicionVerdaderaEscudo == new Vector3(0.0f, 0.0f, 0.0f)) {

            
        
        }

        if (posicionVerdaderaAgujero == new Vector3 (0.0f, 0.0f, 0.0f))
        {
            posicionVerdaderaAgujero = GameObject.FindGameObjectWithTag("controlador").GetComponent<SpawnPowerups>().guardarPosicionAgujero;

        }

        if (posicionVerdaderaGirador == new Vector3 (0.0f, 0.0f, 0.0f))
        {
            posicionVerdaderaGirador = GameObject.FindGameObjectWithTag("controlador").GetComponent<SpawnPowerups>().guardarPosicionGirador;

        }
        */

        //esto causa problemas, ya que la variable donde se guarda la posicion anterior de los powerups se pierde...
        if (GameObject.FindGameObjectWithTag("guardaResultados")!=null && GameObject.FindGameObjectWithTag("guardaResultados")!= this.gameObject)
        {
            DestroyObject(GameObject.FindGameObjectWithTag("guardaResultados"));
        }
        
        DontDestroyOnLoad(this.gameObject);


        if (GameObject.FindGameObjectWithTag("mejorar") != null)
        {
            
            puntosPorUtilizar = GameObject.FindGameObjectWithTag("mejorar").GetComponent<PuntosEstado>().getPuntosPorUtilizar();
            currentLifePoints = GameObject.FindGameObjectWithTag("mejorar").GetComponent<PuntosEstado>().getLifePoints();
            currentStaminaPoints = GameObject.FindGameObjectWithTag("mejorar").GetComponent<PuntosEstado>().getStaminaPoints();
            currentRatioPoints = GameObject.FindGameObjectWithTag("mejorar").GetComponent<PuntosEstado>().getRatioPoints();
            
            

            //print("tenemos " + puntosPorUtilizar + " puntos por gastar");
        }

        if (GameObject.FindGameObjectWithTag("spawnerOleadas") != null)
        {
            round = GameObject.FindGameObjectWithTag("spawnerOleadas").GetComponent<SpawnerOleadas>().getRondaActual();

        }

        //GameObject.FindGameObjectWithTag("mejorar").GetComponent<PuntosEstado>().SaveResultsStarted = true;
        
        
        

    }
    
    public void guardaResultados()
    {

        //if (GameObject.FindGameObjectWithTag("spawnerOleadas").GetComponent<SpawnerOleadas)

        round = GameObject.FindGameObjectWithTag("spawnerOleadas").GetComponent<SpawnerOleadas>().getRondaActual();
        enemies = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoNave>().getEnemigosAbatidos();
        bullets = GameObject.FindGameObjectWithTag("disparadorNave").GetComponent<Disparador>().getBalasUsadas();

        vidaMaxima = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoNave>().getVidaMaximaNave();
        staminaMaxima = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoNave>().getContadorUso();
        cadenciaMaxima = GameObject.FindGameObjectWithTag("disparadorNave").GetComponent<Disparador>().getCadencia();

    }
    public float getPuntosPorUtilizar()
    {
        return puntosPorUtilizar;
    }

    public float getRound()
    {
        return round;
    }
    public float getEnemies()
    {
        return enemies;

    }
    public float getBullets()
    {
        return bullets;
    }

    public void setEnemies(float value)
    {
        enemies = value;

    }
    public void setBullets(float value)
    {
        bullets = value;
    }
	public float getVidaMaxima()
    {
        return vidaMaxima;
    }
    public float getStaminaMaxima()
    {
        return staminaMaxima;
    }
    public float getCadenciaMaxima()
    {
        return cadenciaMaxima;
    }

    public void setVidaMaxima(float value)
    {
        vidaMaxima = value;

    }
    public void setStaminaMaxima(float value)
    {
        staminaMaxima = value;
    }
    public void setCadenciaMaxima(float value)
    {
        cadenciaMaxima = value;
    }

    public void setPuntosPorUtilizar(float cant)
    {

        puntosPorUtilizar = cant;
        //GameObject.FindGameObjectWithTag("mejorar").GetComponent<PuntosEstado>().setPuntosPorUtilizar(puntosPorUtilizar);

    }
    // Update is called once per frame
    void Update()
    {

		print (getBolasRestantes());
		//print ("El escudo está " + shieldOnActive + " y el girador está " + fireBallsOnActive);
        
//		if (GameObject.FindGameObjectWithTag ("controlador") != null) {
//
//			bolasRestantes = GameObject.FindGameObjectWithTag ("controlador").GetComponent<SpawnPowerups> ().bolasRestantes;
//		}
//			
		if (GameObject.FindGameObjectWithTag ("escudoProtector") != null) {


			posicionVerdaderaEscudo = GameObject.FindGameObjectWithTag ("escudoProtector").transform.position;
			shieldOnActive = GameObject.FindGameObjectWithTag ("controlador").GetComponent<SpawnPowerups> ().escudoActivado;
		//			print (shieldOnActive);

		} 
//		else {
//
//			print ("no existe escudo protector");
//		}
		if (GameObject.FindGameObjectWithTag ("agujeroNegro") != null) {


			posicionVerdaderaAgujero = GameObject.FindGameObjectWithTag ("agujeroNegro").transform.position;
		}

		if (GameObject.FindGameObjectWithTag ("powerupBolas") != null) {

			posicionVerdaderaGirador = GameObject.FindGameObjectWithTag ("powerupBolas").transform.position;
			fireBallsOnActive = GameObject.FindGameObjectWithTag ("controlador").GetComponent<SpawnPowerups> ().giradorActivado;

		}
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            currentLife = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoNave>().vidaNaveEspacial;
            currentStamina = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoNave>().contadorUso;
            currentPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            currentRotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;
            currentDefeatedEnemies = enemies;

            
            
        }
       /*
        if (GameObject.FindGameObjectWithTag("controlador") != null)
        {

            if (GameObject.FindGameObjectWithTag("controlador").GetComponent<SpawnPowerups>().escudoProtector != null)
            {

                escudoPosition = GameObject.FindGameObjectWithTag("controlador").GetComponent<SpawnPowerups>().escudoProtector.transform.position;
                print(escudoPosition);
                

            }
            else
            {
                escudoPosition = new Vector3(0, 0, 0);

            }
            if (GameObject.FindGameObjectWithTag("controlador").GetComponent<SpawnPowerups>().agujeroNegro != null)
            {

                agujeroNegroPosition = GameObject.FindGameObjectWithTag("controlador").GetComponent<SpawnPowerups>().agujeroNegro.transform.position;
            }
           

            if (GameObject.FindGameObjectWithTag("controlador").GetComponent<SpawnPowerups>().bolasGiratorias != null)
            {
                giradorPosition = GameObject.FindGameObjectWithTag("controlador").GetComponent<SpawnPowerups>().bolasGiratorias.transform.position;
            }
            else
            {
                giradorPosition = new Vector3(0, 0, 0);

            }

        }
       */



       // puntosPorUtilizar = GameObject.FindGameObjectWithTag("mejorar").GetComponent<PuntosEstado>().getPuntosPorUtilizar();
    }

    public float getCurrentLife()
    {
        return currentLife;
    }
    public float getCurrentDefeatedEnemies()
    {
        return currentDefeatedEnemies;
    }
    public float getCurrentStamina()
    {
        return currentStamina;
    }
    public Vector3 getCurrentPosition()
    {
        return currentPosition;
    }

    public float getCurrentLifePoints()
    {
        return currentLifePoints;
    }
    public float getCurrentStaminaPoints()
    {
        return currentStaminaPoints;
    }
    public float getCurrentRatioPoints()
    {
        return currentRatioPoints;
    }
    public Quaternion getCurrentRotation()
    {

        return currentRotation;
    }
    
	public float getBolasRestantes(){

		return bolasRestantes;
	}
	public void SetUnaBolaMenos(){

		bolasRestantes--;
	}
	public void setBolasRestantesDeInicio(){
		bolasRestantes = 4f;
	}
}
