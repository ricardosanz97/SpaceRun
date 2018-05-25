using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//needed

public class SpawnerOleadas : MonoBehaviour {

    public string eleccion;
    public float rondaComienzo;

    public Canvas minave;

    public int balasDestruirEnemigo;

    public Text texto;
    public Text ronda;
    public Text enemigosRestantes;

    public Canvas waveInfoCanvas;
    public Canvas CurrentRound;
    public Canvas EnemiesLeft;

    public float contadorOleadas;
    public float enemiesLeft;

    public bool mensajeEnPantalla;


    public float tiempoMensajesPantalla;
    private float contadorTiempoMensajePantalla;

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Oleada
    {
        public string nombre;
        public Transform enemigo;
        public int count;
        public float rate;
        public int balasSerDestruido;
        public int getBalas()
        {
            return balasSerDestruido;
        }
    }
    
    

    public Oleada[] waves;
    private int siguienteOleada = 0;

    public Transform[] puntosSpawn;

    public float tiempoEntreOleadas = 5f;
    private float cuentaAtrasOleadas;

    private float buscarCuentaAtras = 1f;

    private SpawnState state = SpawnState.COUNTING;

    private Oleada oleadaAux;
    private float rondaActual;

    void Start()
    {
        //balasDestruirEnemigo =
        //vida del enemigo


        minave.gameObject.SetActive(false);

        eleccion = GameObject.FindGameObjectWithTag("mejorar").GetComponent<PuntosEstado>().getComienzo();
        rondaComienzo = GameObject.FindGameObjectWithTag("mejorar").GetComponent<PuntosEstado>().getRondaComienzo();

        if (GameObject.FindGameObjectWithTag("guardaResultados") != null)
        {

            rondaActual = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getRound();
            contadorOleadas = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().currentRound;



        }

        CurrentRound.gameObject.SetActive(false);
        EnemiesLeft.gameObject.SetActive(false);

        //print(GameObject.FindGameObjectWithTag("menu2").GetComponent<Controlador2>().GetTipoComienzo());

        if (eleccion == "elegir")
        {

            if (rondaComienzo == 5)
            {
                contadorOleadas = 5f;
                siguienteOleada = 4;

            }
            else if (rondaComienzo == 10)
            {
                contadorOleadas = 10f;
                siguienteOleada = 9;
            }
            else if (rondaComienzo == 15)
            {
                contadorOleadas = 15f;
                siguienteOleada = 14;

            }
            else if (rondaComienzo == 20)
            {
                contadorOleadas = 20f;
                siguienteOleada = 19;
            }
            





        }

        else if ( eleccion == "nueva")
        {

            contadorOleadas = 1f;
            siguienteOleada = 0;




        }

        else if (eleccion == "vengoDeUnaPausa")
        {
            contadorOleadas = getRondaActual() + 1;
            siguienteOleada = Mathf.RoundToInt(getRondaActual());



        }
        
        

        //DontDestroyOnLoad(this.gameObject);
       
        contadorTiempoMensajePantalla = 0f;
        tiempoMensajesPantalla = 2f;


        waveInfoCanvas.gameObject.SetActive(false);

        //print("empezamos desde la ronda " + rondaComienzo);
        //texto = gameObject.GetComponent<Text>();
        //texto.text = "XDD";

        if (puntosSpawn.Length == 0)
        {
            Debug.LogError("No hay referencias a puntos de spawn");
        }
        cuentaAtrasOleadas = tiempoEntreOleadas;
    }

    void Update()
    {
        
        


        enemigosRestantes.text = "" + enemiesLeft;
        
        if (mensajeEnPantalla)
        {

            contadorTiempoMensajePantalla += Time.deltaTime;
            if (contadorTiempoMensajePantalla >= tiempoMensajesPantalla)
            {
                mensajeEnPantalla = false;
                contadorTiempoMensajePantalla = 0f;



            }

        }
        if (!mensajeEnPantalla)
        {

            waveInfoCanvas.gameObject.SetActive(false);
            mensajeEnPantalla = false;

        }

        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                OleadaCompleta();

            }
            else
            {
                return;
            }
        }
        if (cuentaAtrasOleadas <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnOleada(waves[siguienteOleada]));
            }
        }
        else
        {
            cuentaAtrasOleadas -= Time.deltaTime;

        }

        
        
    }

    void OleadaCompleta()
    {
        //GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoNave>().vidaNaveEspacial = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoNave>().auxVidaNaveEspacial;
        GameObject.FindGameObjectWithTag("salud").GetComponent<Salud>().regeneraVida();
        minave.gameObject.SetActive(true);
        //+1 punto para estado
        GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().setPuntosPorUtilizar(GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getPuntosPorUtilizar() + 1);
        print("hemos completado la oleada y ganamos un punto, ahora tenemos: " + GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getPuntosPorUtilizar());
        //aumentamos vida de los enemigos
        //balasDestruirEnemigo += 5;
        //GameObject.FindGameObjectWithTag("Enemigo").GetComponent<Collisionador>().numBalasParaSerDestruido = balasDestruirEnemigo;

        CurrentRound.gameObject.SetActive(false);
        EnemiesLeft.gameObject.SetActive(false);
        contadorOleadas++;
        mensajeEnPantalla = true;
        waveInfoCanvas.gameObject.SetActive(true);

        texto.text = "OLEADA " + (contadorOleadas - 1) + " COMPLEATADA";

//        Debug.Log("Oleada Completada");
        //texto.text = "OLEADA COMPLETADA";

        state = SpawnState.COUNTING;
        cuentaAtrasOleadas = tiempoEntreOleadas;


        if (siguienteOleada + 1 > waves.Length - 1)
        {
            siguienteOleada = 0;
            Debug.Log("Todas las oleadas completadas");

            print("cambiando escena fin del juego victoria");
            SceneManager.LoadScene("OleadasCompletadas");

        }
        else
        {
            siguienteOleada++;
//            Debug.Log("Siguiente oleada");
        }

    }

    

    bool EnemyIsAlive()
    {
        buscarCuentaAtras -= Time.deltaTime;
        if (buscarCuentaAtras <= 0f)
        {
            buscarCuentaAtras = 1f;
            if (GameObject.FindGameObjectWithTag("Enemigo") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnOleada(Oleada _wave)
    {

        minave.gameObject.SetActive(false);
        //print(_wave.balasSerDestruido);
        if (GameObject.FindGameObjectWithTag("guardaResultados") != null)
        {

            GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().currentRound = contadorOleadas;

        }

        balasDestruirEnemigo = _wave.balasSerDestruido;

        enemiesLeft = _wave.count;

        waveInfoCanvas.gameObject.SetActive(true);

        
        CurrentRound.gameObject.SetActive(true);

        EnemiesLeft.gameObject.SetActive(true);

        ronda.text = "" + contadorOleadas;
        enemigosRestantes.text = "" + _wave.count;

        mensajeEnPantalla = true;

        texto.text = "OLEADA " + contadorOleadas;
        
//        Debug.Log("Spawning oleada" + _wave.nombre);

        
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            Spawn(_wave.enemigo);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void Spawn(Transform _enemigo1)
    {
//        Debug.Log("Spawning enemigo" + _enemigo1.name);

        Transform _sp = puntosSpawn[Random.Range(0, puntosSpawn.Length)];
        Instantiate(_enemigo1, _sp.position, _sp.rotation);

    }

    public float getRondaActual()
    {
        return contadorOleadas;

    }
    public int getBalasDestruirEnemigo()
    {

        return balasDestruirEnemigo;
    }
}

