using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MovimientoNave : MonoBehaviour {

    private Animator animator;
    public float seedSpeed = 5f;
    public float padding = 2f;
    private float speed;
    public GameObject sistema1;
    public GameObject sistema2;
    public Light luz1;
    public Light luz2;
    public bool escudoActivado;
    public bool activarTemporizadorEscudo;
    public float vidaNaveEspacial;
    public float auxVidaNaveEspacial;
    public bool giradorBolasActivado;
    public bool activarTemporizadorBolas;
    private float auxiliarContadorUso;

    public float enemigosAbatidos;

    public float vidaQueNosHanQuitado;

    //Variables para el turbo
    public float contadorUso;
    
	bool gastado = false;
	public Image barraTurbo;

    public void setSpeed(float semillaVel)
    {
        speed = semillaVel * Time.deltaTime;
    }

    // Use this for initialization
    void Start () {

        //DontDestroyOnLoad(this.gameObject);

        if (GameObject.FindGameObjectWithTag("mejorar").GetComponent<PuntosEstado>().getComienzo() == "vengoDeUnaPausa")
        {

            this.gameObject.transform.position = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getCurrentPosition();
            this.gameObject.transform.rotation = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getCurrentRotation();
            //vidaNaveEspacial =  GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getCurrentLife();
            contadorUso = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getCurrentStamina();

            

        }

        animator = GetComponent<Animator>();
        sistema1.GetComponent<ParticleSystem>().Stop();
        sistema2.GetComponent<ParticleSystem>().Stop();

        vidaNaveEspacial = GameObject.FindGameObjectWithTag("mejorar").GetComponent<PuntosEstado>().getVidaMaxima();
        //print("vida fijada a " + vidaNaveEspacial);

        

        contadorUso = GameObject.FindGameObjectWithTag("mejorar").GetComponent<PuntosEstado>().getStaminaMaxima();
        //print("stamina fijada a "+ contadorUso);
        GameObject.FindGameObjectWithTag("disparadorNave").GetComponent<Disparador>().setCadencia
            (GameObject.FindGameObjectWithTag("mejorar").GetComponent<PuntosEstado>().getCadenciaMaxima());
        //print("cadencia fijada a " + GameObject.FindGameObjectWithTag("disparadorNave").GetComponent<Disparador>().getCadencia());


		//GameObject.FindGameObjectWithTag ("guardaResultados").GetComponent<SaveResults> ().shieldOnActive = GameObject.FindGameObjectWithTag ("mejorar").GetComponent<PuntosEstado> ().escudoActivado;

		//GameObject.FindGameObjectWithTag ("mejorar").GetComponent<PuntosEstado> ().escudoActivado =GameObject.FindGameObjectWithTag ("guardaResultados").GetComponent<SaveResults> ().shieldOnActive;



        DestroyObject(GameObject.FindGameObjectWithTag("mejorar"));

        enemigosAbatidos = 0f;
        //DontDestroyOnLoad(this.gameObject);
        auxVidaNaveEspacial = vidaNaveEspacial;
        auxiliarContadorUso = contadorUso;

        //vidaNaveEspacial = auxVidaNaveEspacial - vidaQueNosHanQuitado; //ESTO NO PUTO FUNCIONA JODER!
    }
    public float getVidaQueNosHabianQuitado()
    {
        return vidaQueNosHanQuitado;
    }
	// Update is called once per frame
	void Update () {

        if (GameObject.FindGameObjectWithTag("mejorar") != null)
        {
            print(GameObject.FindGameObjectWithTag("mejorar").GetComponent<Controlador4>().getVengoDeMejorar());
        }
        
        escudoActivado = GameObject.FindGameObjectWithTag("controlador").GetComponent<SpawnPowerups>().escudoActivado;

        //print(vidaNaveEspacial);
//        print("escudo : " + escudoActivado + " y girador: " + giradorBolasActivado);
        
        //print(this.gameObject.transform.position);

        setSpeed(seedSpeed);

        //vidaQueNosHanQuitado = auxVidaNaveEspacial - vidaNaveEspacial;

        if (Input.GetKey(KeyCode.K))
        {
            destruirNave();
        }
        if (gastado == false) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                contadorUso -= Time.deltaTime;
                barraTurbo.fillAmount -= (float)1 / auxiliarContadorUso * Time.deltaTime;
                //print (contadorUso);
                setSpeed(seedSpeed * 2);
                if (contadorUso <= 0f) {
                    //print ("Has gastado el TURBO");
                    gastado = true;
                }
            }
            else if (contadorUso < auxiliarContadorUso)
            {
                gastado = true;
            }
        }
        else {
            
                contadorUso += Time.deltaTime;
                barraTurbo.fillAmount += (float)1 / auxiliarContadorUso * Time.deltaTime;
                //print (contadorUso);
                if (contadorUso >= auxiliarContadorUso)
                {
                    gastado = false;
                }
        }
    
        
       //MOVIMIENTO HORIZONTAL
        float hInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(hInput * speed, 0, 0);

       //MOVIMIENTO VERTICAL   
        
        float vInput = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, vInput * speed, 0);
        
        //MOVIMIENTO ALTERNATIVO SOLO W
        /*
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), speed * 100 * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);


        }
        */
        
        

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey("right") || Input.GetKey("left") || Input.GetKey("up") || Input.GetKey("down"))
        {
            if ((Input.GetKey(KeyCode.LeftShift)) && gastado == false)
            {
                sistema1.GetComponent<ParticleSystem>().Play();
                sistema2.GetComponent<ParticleSystem>().Play();
                luz1.enabled = true;
                luz2.enabled = true;
            }
            else
            {
                sistema1.GetComponent<ParticleSystem>().Stop();
                sistema2.GetComponent<ParticleSystem>().Stop();
                luz1.enabled = false;
                luz2.enabled = false;
            }


            animator.ResetTrigger("Levantar");
            animator.SetTrigger("Pulsar tecla");
        }


        else
        {
            animator.ResetTrigger("Pulsar tecla");
            animator.SetTrigger("Levantar");

            sistema1.GetComponent<ParticleSystem>().Stop();
            sistema2.GetComponent<ParticleSystem>().Stop();

            luz1.enabled = false;
            luz2.enabled = false;
        }

        //LIMITAR MOVIMIENTO

        float newX = Mathf.Clamp(transform.position.x, -60 + padding, 60 - padding);
        float newY = Mathf.Clamp(transform.position.y, -30 + padding, 30 - padding);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         
        if (collision.tag == "Enemigo")
        {
            
            if (escudoActivado==false)
            {
                GameObject.Find("NaveEspacialBrillo1").GetComponent<MovimientoNave>().vidaNaveEspacial -= GameObject.FindGameObjectWithTag("Enemigo").GetComponent<Collisionador>().danyoExplosionNavePrincipal;
                GameObject.FindGameObjectWithTag("salud").GetComponent<Salud>().SetVida(GameObject.FindGameObjectWithTag("Enemigo").GetComponent<Collisionador>().danyoExplosionNavePrincipal / auxVidaNaveEspacial);
                collision.GetComponent<Collisionador>().destruirEnemigo1();
                if (GameObject.Find("NaveEspacialBrillo1").GetComponent<MovimientoNave>().vidaNaveEspacial <= 0)
                {
                    destruirNave();
                }

            }
            
            
            
        }
        if (collision.tag == "agujeroNegro")
        {
            float nuevaX = Random.Range(-55, 55);
            float nuevaY = Random.Range(-27, 27);
            Vector3 nuevaPos = new Vector3(nuevaX, nuevaY, -10);
            transform.position = nuevaPos;
            
        }
        if (collision.tag == "escudoProtector")
        {
            GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().shieldOnActive = true;
            //print(transform.position);





        }
		if (collision.tag == "powerupBolas") {
      
            GameObject.Find("GameController").GetComponent<SpawnPowerups>().activarGiradorBolas(4f);
            GameObject.Find("GameController").GetComponent<SpawnPowerups>().contadorDuracionBolas = 0f;


        }
       
    }
    public void destruirNave()
    {

        GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().guardaResultados();
        print("cambiando escena a GAME OVER");
        SceneManager.LoadScene("GameOver");

        print("GAME OVER, la nave ha sido destruída. ");


    }
    public float getVidaMaximaNave()
    {
        return auxVidaNaveEspacial;
    }

    public float getEnemigosAbatidos()
    {

        return enemigosAbatidos;
    }
    public float getContadorUso()
    {
        return auxiliarContadorUso;
    }
   
}
