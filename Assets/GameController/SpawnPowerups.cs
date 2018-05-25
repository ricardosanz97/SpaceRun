using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerups : MonoBehaviour
{

    //public GUIText texto;

    public float contador;
	public float contador2;

    public float contadorDuracionBolas;
    public float contadorSpawnEscudo;
    public float contadorSpawnBolasGiratorias;
    public GameObject agujeroNegro;
    public GameObject escudoProtector;
    public GameObject bolasGiratorias;
    public bool nuevoSpawneoEscudo = false;
    public bool nuevoSpawneoGiradorBolas = false;
    private float timerSpawnEscudo;
    private float timerSpawnGiradorBolas;
    public bool escudoAcabado;
    public bool bolasGiratoriasAcabadas;

    public bool escudoActivado;
    public bool giradorActivado;

    private GameObject aux;
    private GameObject aux2;
    private Vector3 aux3;

    public Vector3 guardarPosicionEscudo;
    public Vector3 guardarPosicionGirador;
    public Vector3 guardarPosicionAgujero;

	public float bolasRestantes;
    //public bool[] powerupsActivos = new bool[2];

    // Use this for initialization
    void Start()
    {
        
		bolasRestantes = GameObject.FindGameObjectWithTag ("guardaResultados").GetComponent<SaveResults> ().getBolasRestantes ();

        aux3 = new Vector3(0, 0, 0);
        //DontDestroyOnLoad(this.gameObject);

        if (GameObject.FindGameObjectWithTag("mejorar") != null)//si existe mejorar...
        {
            aux = GameObject.FindGameObjectWithTag("mejorar");

            if (aux.GetComponent<Controlador4>().getVengoDeMejorar() == true)//si venimos de mejorar...
            {
                print("colocamos los powerups donde estaban anteriormente");
                GameObject.Find("EscudoImage").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("giradorImage").GetComponent<SpriteRenderer>().enabled = true;

                GameObject naveConEscudoDeLaNave = GameObject.Find("NaveConEscudo1");
                GameObject navePrincipal = GameObject.Find("NaveEspacialBrillo1");

                desactivarEscudo();
				desactivarGiradorBolas("");


                if (GameObject.FindGameObjectWithTag("guardaResultados") != null)//si existe guardaResultados...
                {

                    aux2 = GameObject.FindGameObjectWithTag("guardaResultados");
					//print ("saveResults existe!");
                    // CUANDO SOLUCIONEMOS PARA CONSERVAR LA VARIABLE QUE GUARDA LA POSICION DE LOS POWERUPS EN LA OLEADA ANTERIOR EN CASO DE NO TOCARLOS, DESCOMENTAR ESTO QUE SIRVE PARA QUE APAREZCA CON EL ESCUDO ACTIVADO EN CASO DE QUE ASI FUESE.
                    if (aux2.GetComponent<SaveResults>().shieldOnActive == true)
                    {


						print ("Hemos pasado la oleada y el escudo sigue activado");


                        GameObject.Find("NaveEspacialBrillo1").GetComponent<MovimientoNave>().activarTemporizadorEscudo = true;
                        activarEscudo();
                        contador = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().currentCounterShield;
						//aux2.GetComponent<SaveResults>().posicionVerdaderaEscudo = new Vector3 (Random.Range (-55, 55), Random.Range (-27, 27), aux2.GetComponent<SaveResults> ().posicionVerdaderaEscudo.z);



                    }
                    
					else if (aux2.GetComponent<SaveResults>().shieldOnActive == false)
                    {
					 
						print ("Hemos pasado la oleada y el escudo no estaba activado");

                    //aux2.GetComponent<SaveResults>().guardarPosicionVerdaderaEscudo = aux2.GetComponent<SaveResults>().posicionVerdaderaEscudo;
                    //Instantiate(escudoProtector, aux2.GetComponent<SaveResults>().guardarPosicionVerdaderaEscudo, transform.rotation);
                   	 	Instantiate(escudoProtector, aux2.GetComponent<SaveResults>().posicionVerdaderaEscudo, transform.rotation);
                   		timerSpawnEscudo = 100000000f;
					

                    

                    


                	}


					if (aux2.GetComponent<SaveResults>().fireBallsOnActive == true) {

						print ("hemos pasado la oleada y el girador esta activado");
						GameObject.Find ("NaveEspacialBrillo1").GetComponent<MovimientoNave> ().activarTemporizadorBolas = true;
						activarGiradorBolas(bolasRestantes);
						//GameObject.FindGameObjectWithTag ("bolita").GetComponent<girador> ().setNumInicialBolas (aux2.GetComponent<SaveResults>().getBolasRestantes());
						contadorDuracionBolas = GameObject.FindGameObjectWithTag ("guardaResultados").GetComponent<SaveResults> ().currentCounterFireBalls;
						//aux2.GetComponent<SaveResults> ().guardarPosicionVerdaderaGirador = new Vector3 (Random.Range (-55, 55), Random.Range (-27, 27), aux2.GetComponent<SaveResults> ().posicionVerdaderaGirador.z);


					} 
					else if (aux2.GetComponent<SaveResults>().fireBallsOnActive == false)
					{

						Instantiate (bolasGiratorias, aux2.GetComponent<SaveResults> ().posicionVerdaderaGirador, transform.rotation);
						//aux2.GetComponent<SaveResults> ().guardarPosicionVerdaderaGirador = aux2.GetComponent<SaveResults> ().posicionVerdaderaGirador;
						timerSpawnGiradorBolas = 1000000000f;
					}


					Instantiate(agujeroNegro, aux2.GetComponent<SaveResults>().posicionVerdaderaAgujero, transform.rotation);
					aux2.GetComponent<SaveResults>().guardarPosicionVerdaderaAgujero = aux2.GetComponent<SaveResults>().posicionVerdaderaAgujero;

                }
                
				//y si vengo de mejorar y esta en nulo...?

				//hay q ver si conforme actua ahora nos gusta, en ese caso lo dejaremos asi, si no nos gusta lo cambiamos...

				aux.GetComponent<Controlador4> ().setVengoDeMejorar (false);
            }


            else
            {
				GameObject.FindGameObjectWithTag ("guardaResultados").GetComponent<SaveResults> ().setBolasRestantesDeInicio ();
                print("inicializamos SpawnPowerups por partida nueva");
                
                GameObject.Find("EscudoImage").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("giradorImage").GetComponent<SpriteRenderer>().enabled = false;
                escudoAcabado = true;
                bolasGiratoriasAcabadas = true;
                timerSpawnEscudo = Random.Range(3, 6); //que tardará en spawnearse por primera vez...
                                                       //print(timerSpawnEscudo);
                timerSpawnGiradorBolas = Random.Range(3, 6); //que tardará en spawnearse por primera vez...
                GameObject naveConEscudoDeLaNave = GameObject.Find("NaveConEscudo1");
                GameObject navePrincipal = GameObject.Find("NaveEspacialBrillo1");

                //DE INICIO, ESCUDO DESACTIVADO
                desactivarEscudo();
                //DE INICIO, BOLAS GIRATORIAS DESACTIVADAS
                desactivarGiradorBolas("4bolas");
                

                float posX = Random.Range(-55, 55);
                float posY = Random.Range(-27, 27);
                Vector3 newPos = new Vector3(posX, posY, -10);
                Instantiate(agujeroNegro, newPos, transform.rotation);
                GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().posicionVerdaderaAgujero = newPos;


            }

        }

        



        


        
        

        
    }
    // Update is called once per frame
    void Update()
    {
		bolasRestantes = GameObject.FindGameObjectWithTag ("guardaResultados").GetComponent<SaveResults> ().getBolasRestantes ();

		if (bolasRestantes <= 0) {
			bolasRestantes = 0;
		}
		if (GameObject.FindGameObjectWithTag ("guardaResultados") != null) {
			escudoActivado = GameObject.FindGameObjectWithTag ("guardaResultados").GetComponent<SaveResults> ().shieldOnActive; 
		}

        //print(GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().posicionVerdaderaEscudo);
        procesoEscudo();
        procesoBolasGiratorias();
        if (nuevoSpawneoEscudo == true && escudoAcabado==true)
        {

           
                spawnPowerupEscudo();
                nuevoSpawneoEscudo = false;
                //print("Ya no se spawnea mas. ");   
        }

        else if (nuevoSpawneoEscudo == false)
        {
                contadorSpawnEscudo += Time.deltaTime;
                if (contadorSpawnEscudo >= timerSpawnEscudo)
                {

                    nuevoSpawneoEscudo = true;
                    //print("Se vuelve a spawnear. ");
                    contadorSpawnEscudo = 0;
                    timerSpawnEscudo = 1000000000f;

                }
         }

        if (nuevoSpawneoGiradorBolas==true && bolasGiratoriasAcabadas == true)
        {
            spawnPowerupBolasGiratorias();
            nuevoSpawneoGiradorBolas = false;
            //print("Ya no se spawnea mas 2. ");

        }          
        else if (nuevoSpawneoGiradorBolas == false)
        {

            contadorSpawnBolasGiratorias += Time.deltaTime;
            if (contadorSpawnBolasGiratorias >= timerSpawnGiradorBolas)
            {

                nuevoSpawneoGiradorBolas = true;
                contadorSpawnBolasGiratorias = 0;
                timerSpawnGiradorBolas = 100000f;
            }

        }
    }
    public void activarEscudo()
    {
        escudoActivado = true;
		GameObject.FindGameObjectWithTag ("guardaResultados").GetComponent<SaveResults> ().shieldOnActive = true;
        GameObject.Find("EscudoImage").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("EscudoImage").GetComponent<SpriteRenderer>().sortingOrder = 1;
        //powerupsActivos[0] = true;
        //print("SKIN");
        escudoAcabado = false;
        GameObject.Find("NaveEspacialBrillo1").GetComponent<MovimientoNave>().activarTemporizadorEscudo = true;
        GameObject.Find("NaveConEscudo1").GetComponent<Renderer>().enabled = true;
        GameObject.Find("NaveConEscudo1").GetComponent<Parpadeo>().activarEscudo = true;
        //GameObject.Find("NaveConEscudo1").GetComponent<Parpadeo>().luzParpadeando.intensity = 0;
        GameObject.Find("NaveConEscudo1").GetComponent<CircleCollider2D>().enabled = true;
   
    }
	public void desactivarEscudo()
    {
		
        //GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().shieldOnActive = false;
        escudoActivado = false;
        GameObject.Find("EscudoImage").GetComponent<SpriteRenderer>().enabled = false;
        //powerupsActivos[0] = false;
        escudoAcabado = true;
        GameObject.Find("NaveEspacialBrillo1").GetComponent<MovimientoNave>().activarTemporizadorEscudo = false;
        GameObject.Find("NaveConEscudo1").GetComponent<Renderer>().enabled = false;
        GameObject.Find("NaveConEscudo1").GetComponent<Parpadeo>().activarEscudo = false;
        GameObject.Find("NaveConEscudo1").GetComponent<Parpadeo>().luzParpadeando.intensity = 0;
        GameObject.Find("NaveConEscudo1").GetComponent<CircleCollider2D>().enabled = false;


    }
	public void activarGiradorBolas(float ballsNumber)
    {


		GameObject.FindGameObjectWithTag ("guardaResultados").GetComponent<SaveResults> ().fireBallsOnActive = true;
		giradorActivado = true;
		//powerupsActivos[1] = true;
		GameObject.Find("giradorImage").GetComponent<SpriteRenderer>().enabled = true;
		GameObject.Find("giradorImage").GetComponent<SpriteRenderer>().sortingOrder = 0;
		GameObject.Find("BolasGiratorias").GetComponent<girador>().setNumInicialBolas(ballsNumber);
		bolasGiratoriasAcabadas = false;
		GameObject.Find("NaveEspacialBrillo1").GetComponent<MovimientoNave>().activarTemporizadorBolas = true;
		GameObject.Find("NaveEspacialBrillo1").GetComponent<MovimientoNave>().giradorBolasActivado = true;

		if (ballsNumber == 3f) {
			
			GameObject.Find ("bolita1").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bolita2").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bolita3").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bolita4").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bolita1").GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.Find ("bolita2").GetComponent<CircleCollider2D> ().enabled = true;
			GameObject.Find ("bolita3").GetComponent<CircleCollider2D> ().enabled = true;
			GameObject.Find ("bolita4").GetComponent<CircleCollider2D> ().enabled = true;

		} else if (ballsNumber == 2f) {
			
			GameObject.Find ("bolita1").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bolita2").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bolita3").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bolita4").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bolita1").GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.Find ("bolita2").GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.Find ("bolita3").GetComponent<CircleCollider2D> ().enabled = true;
			GameObject.Find ("bolita4").GetComponent<CircleCollider2D> ().enabled = true;

		} else if (ballsNumber == 1f) {
			
			GameObject.Find ("bolita1").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bolita2").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bolita3").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("bolita4").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("bolita1").GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.Find ("bolita2").GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.Find ("bolita3").GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.Find ("bolita4").GetComponent<CircleCollider2D> ().enabled = true;

		} 
		else if (ballsNumber == 4f)
		{
			GameObject.Find("bolita1").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("bolita2").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("bolita3").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("bolita4").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("bolita1").GetComponent<CircleCollider2D>().enabled = true;
			GameObject.Find("bolita2").GetComponent<CircleCollider2D>().enabled = true;
			GameObject.Find("bolita3").GetComponent<CircleCollider2D>().enabled = true;
			GameObject.Find("bolita4").GetComponent<CircleCollider2D>().enabled = true;
		}




     
    }
	public void desactivarGiradorBolas(string info)
    {
        giradorActivado = false;
        //powerupsActivos[1] = false;
        GameObject.Find("giradorImage").GetComponent<SpriteRenderer>().enabled = false;
        bolasGiratoriasAcabadas = true;
        GameObject.Find("NaveEspacialBrillo1").GetComponent<MovimientoNave>().activarTemporizadorBolas = false;
        GameObject.Find("NaveEspacialBrillo1").GetComponent<MovimientoNave>().giradorBolasActivado = false;
        GameObject.Find("bolita1").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("bolita2").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("bolita3").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("bolita4").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("bolita1").GetComponent<CircleCollider2D>().enabled = false;
        GameObject.Find("bolita2").GetComponent<CircleCollider2D>().enabled = false;
        GameObject.Find("bolita3").GetComponent<CircleCollider2D>().enabled = false;
        GameObject.Find("bolita4").GetComponent<CircleCollider2D>().enabled = false;
		//bolasRestantes = 4f;
		//GameObject.FindGameObjectWithTag ("guardaResultados").GetComponent<SaveResults> ().setBolasRestantesDeInicio ();
		if (info == "4bolas") {
			GameObject.FindGameObjectWithTag ("guardaResultados").GetComponent<SaveResults> ().setBolasRestantesDeInicio ();
			bolasRestantes = 4f;
		}
    }
    public void spawnPowerupEscudo()
    {

        float otraposX = Random.Range(-55, 55);
        float otraposY = Random.Range(-27, 27);
        Vector3 newPos2 = new Vector3(otraposX, otraposY, -10);
        Instantiate(escudoProtector, newPos2, transform.rotation);
        GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().posicionVerdaderaEscudo = newPos2;
        



       //print("Escudo spawneado");
    }
    public void spawnPowerupBolasGiratorias()
    {
        float pos2X = Random.Range(-55, 55);
        float pos2Y = Random.Range(-27, 27);
        Vector3 newPos2 = new Vector3(pos2X, pos2Y, -10);
        Instantiate(bolasGiratorias, newPos2, transform.rotation);
        GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().posicionVerdaderaGirador = newPos2;
        
        //print("Girador spawneado");
    }
    public void procesoEscudo()
    {
        if (GameObject.Find("NaveEspacialBrillo1") != null)
        {
            
            if (GameObject.Find("NaveEspacialBrillo1").GetComponent<MovimientoNave>().activarTemporizadorEscudo == true)//si ha colisionado con el powerup
            {
                
                contador += Time.deltaTime;
                GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().currentCounterShield = contador;
                if (contador >= GameObject.Find("NaveConEscudo1").GetComponent<Parpadeo>().duracionActivacion)
                {
                    //SI LLEGA AL TIEMPO LIMITE, SE DESACTIVA EL ESCUDO
                    desactivarEscudo();
                    nuevoSpawneoEscudo = false;
                    timerSpawnEscudo = Random.Range(10,30);
                    contadorSpawnEscudo = 0;


                }
            }
        }

    }
    public void procesoBolasGiratorias()
    {
        if (GameObject.Find("NaveEspacialBrillo1") != null)
        {

            if (GameObject.Find("NaveEspacialBrillo1").GetComponent<MovimientoNave>().activarTemporizadorBolas == true)//si ha colisionado con el powerup
            {

                contadorDuracionBolas += Time.deltaTime;
				GameObject.FindGameObjectWithTag ("guardaResultados").GetComponent<SaveResults> ().currentCounterFireBalls = contadorDuracionBolas;
                if (contadorDuracionBolas >= GameObject.Find("BolasGiratorias").GetComponent<girador>().duracionActivacionBolasGiratorias)
                {
                    //SI LLEGA AL TIEMPO LIMITE, SE DESACTIVA EL ESCUDO
                    desactivarGiradorBolas("4bolas");
                    nuevoSpawneoGiradorBolas = false;
                    timerSpawnGiradorBolas = Random.Range(10, 30);
                    contadorSpawnBolasGiratorias = 0;


                }
            }
        }

    }
    public float getTimerAparicionEscudo()
    {
        return timerSpawnEscudo;
    }
    public float getTimerAparicionBolasGiratorias()
    {
        return timerSpawnGiradorBolas;
    }
    public void setTimerAparicionEscudo(float random)
    {
        timerSpawnEscudo = random;
    }
    public void setTimerAparicionBolasGiratorias(float random)
    {
        timerSpawnGiradorBolas = random;
    }


}
