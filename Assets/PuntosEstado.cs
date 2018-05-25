using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntosEstado : MonoBehaviour {

    public Text currentLife;
    public Text currentStamina;
    public Text currentRatio;

    public float currentRound;

    public Text puntosRestantes;
    public float currentPoints = 0f;

    public Button masVida;
    public Button menosVida;
    public Button masTurbo;
    public Button menosTurbo;
    public Button masCadencia;
    public Button menosCadencia;

    public Button hecho;
    public Button continuar;
    public Button atras;

    public float life;
    public float stamina;
    public float ratio;

    public float lifePoints;
    public float staminaPoints;
    public float ratioPoints;

    private string comienzo;
    //private string continuar;

    private float rondaComienzo;

	public bool escudoActivado;

    //public bool SaveResultsStarted = false;
	// Use this for initialization
	void Start () {
        
		DontDestroyOnLoad(this.gameObject);



		//print ("holis vecinito");
			
        
        

        if (GameObject.FindGameObjectWithTag("guardaResultados")!=null)
        {
			
			escudoActivado = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().shieldOnActive;
			//print ("guardamos");

            currentRound = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().currentRound;
            currentPoints = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getPuntosPorUtilizar();

            lifePoints = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getCurrentLifePoints();
            staminaPoints = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getCurrentStaminaPoints();
            ratioPoints = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getCurrentRatioPoints();


            if (GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().botonMiNavePulsado == true)
            {
                hecho.gameObject.SetActive(true);
                continuar.enabled = false;
                atras.enabled = false;
                //atras.transform.position = new Vector3(400, 400, 10);
                //continuar.transform.position = new Vector3(400, 400, 10);
                Destroy(continuar.gameObject);
                Destroy(atras.gameObject);
                hecho.enabled = true;
                hecho.transform.position = new Vector3(hecho.transform.position.x, hecho.transform.position.y - 20, hecho.transform.position.z);
                comienzo = "vengoDeUnaPausa";

                if (GameObject.FindGameObjectWithTag("menu2") != null)
                {
                    DestroyObject(GameObject.FindGameObjectWithTag("menu2"));

                }
                
                

            }
            else
            {
                continuar.enabled = true;
                hecho.enabled = false;


                comienzo = ""; //ESTO PUEDE CAUSAR PROBLEMAS!!!

            }
            GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().botonMiNavePulsado = false;
            //print("tenemos " + currentPoints + " para gastar");
        }
        

        if (GameObject.FindGameObjectWithTag("menu2") != null){
            comienzo = GameObject.FindGameObjectWithTag("menu2").GetComponent<Controlador2>().GetTipoComienzo();


        }


        //puntosRestantes.text = "";



        if (comienzo == "elegir")
        {
            rondaComienzo = GameObject.FindGameObjectWithTag("rondaElegida").GetComponent<Controlador3>().GetRondaElegida();
            if (rondaComienzo == 5)
            {
                GameObject.FindGameObjectWithTag("menu2").GetComponent<Controlador2>().SetTipoComienzo("");
                GameObject.FindGameObjectWithTag("rondaElegida").GetComponent<Controlador3>().SetRondaElegida(-1);
                DestroyObject(GameObject.FindGameObjectWithTag("menu2"));
                print("ronda 5");
                currentPoints = 5f;
                lifePoints = 1f;
                staminaPoints = 1f;
                ratioPoints = 1f;
                
                




            }
            else if (rondaComienzo==10)
            {
                GameObject.FindGameObjectWithTag("menu2").GetComponent<Controlador2>().SetTipoComienzo("");
                GameObject.FindGameObjectWithTag("rondaElegida").GetComponent<Controlador3>().SetRondaElegida(-1);
                DestroyObject(GameObject.FindGameObjectWithTag("menu2"));
//                print("ronda 10");
                currentPoints = 10f;
                lifePoints = 1f;
                staminaPoints = 1f;
                ratioPoints = 1f;
               


            }
            else if (rondaComienzo==15)
            {
                GameObject.FindGameObjectWithTag("menu2").GetComponent<Controlador2>().SetTipoComienzo("");
                GameObject.FindGameObjectWithTag("rondaElegida").GetComponent<Controlador3>().SetRondaElegida(-1);
                DestroyObject(GameObject.FindGameObjectWithTag("menu2"));
                print("ronda 15");
                currentPoints = 15f;
                lifePoints = 1f;
                staminaPoints = 1f;
                ratioPoints = 1f;
                


            }
            else if (rondaComienzo==20)
            {
                GameObject.FindGameObjectWithTag("menu2").GetComponent<Controlador2>().SetTipoComienzo("");
                GameObject.FindGameObjectWithTag("rondaElegida").GetComponent<Controlador3>().SetRondaElegida(-1);
                DestroyObject(GameObject.FindGameObjectWithTag("menu2"));
                print("ronda20");
                currentPoints = 20f;
                lifePoints = 1f;
                staminaPoints = 1f;
                ratioPoints = 1f;
                




            }
            //DestroyObject(GameObject.FindGameObjectWithTag("menu2"));
            //GameObject.FindGameObjectWithTag("menu2").GetComponent<Controlador2>().SetTipoComienzo("");


        }
        else if (comienzo == "nueva")
        {
           
            GameObject.FindGameObjectWithTag("menu2").GetComponent<Controlador2>().SetTipoComienzo("");
            DestroyObject(GameObject.FindGameObjectWithTag("menu2"));
            
            currentPoints = 0f;
            lifePoints = 1f;
            staminaPoints = 1f;
            ratioPoints = 1f;
            
            //GameObject.FindGameObjectWithTag("rondaElegida").GetComponent<Controlador3>().SetRondaElegida(-1);


        }
        





        //DontDestroyOnLoad(this.gameObject);

        currentLife.text = "" + lifePoints;
        currentStamina.text = "" + staminaPoints;
        currentRatio.text = "" + ratioPoints;

        //life = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getVidaMaxima(); //cada 100 de vida es 1 punto
        //stamina = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getStaminaMaxima();//cada 1,5 de stamina es 1 punto
        //ratio = GameObject.FindGameObjectWithTag("guardaResultados").GetComponent<SaveResults>().getCadenciaMaxima(); //cada 1'5 de cadencia es 1 punto

        puntosRestantes.text = "" + currentPoints;
//        print("tenemos " + currentPoints + " para gastar");


    }
	
	// Update is called once per frame
	void Update () {
        
        actualiza();
        puntosRestantes.text = "" + currentPoints;
        if (currentPoints == 0)
        {
            masVida.enabled = false;
            masTurbo.enabled = false;
            masCadencia.enabled = false;


        }
        else if (currentPoints > 0)
        {
            masVida.enabled = true;
            masTurbo.enabled = true;
            masCadencia.enabled = true;
        }

        if (lifePoints == 1)
        {
            menosVida.enabled = false;

        }
        else if (lifePoints > 1)
        {
            menosVida.enabled = true;
        }
        if (staminaPoints == 1)
        {
            menosTurbo.enabled = false;
        }
        else if ( staminaPoints > 1)
        {
            menosTurbo.enabled = true;
        }
        if (ratioPoints == 1)
        {
            menosCadencia.enabled = false;
        }
        else if (ratioPoints > 1)
        {
            menosCadencia.enabled = true;
        }
        //if (lifePoints == 1 && staminaPoints == 
	}

    public void botonMasVida()
    {
        currentPoints--;
        lifePoints++;
        actualiza();

    }
    public void botonMenosVida()
    {
        currentPoints++;
        lifePoints--;
        actualiza();
    }
    public void botonMasTurbo()
    {
        currentPoints--;
        staminaPoints++;
        actualiza();
    }
    public void botonMenosTurbo()
    {
        currentPoints++;
        staminaPoints--;
        actualiza();
    }
    public void botonMasCadencia()
    {
        currentPoints--;
        ratioPoints++;
        actualiza();
    }
    public void botonMenosCadencia()
    {
        currentPoints++;
        ratioPoints--;
        actualiza();
    }

    public void actualiza()
    {
        life = lifePoints * 100;
        stamina = staminaPoints * 2;
        ratio = ratioPoints * 3;

        currentLife.text = "" + lifePoints;
        currentStamina.text = "" + staminaPoints;
        currentRatio.text = "" + ratioPoints;


    }

    public float getVidaMaxima()
    {
        return life;


    }
    public float getStaminaMaxima()
    {
        return stamina;
    }
    public float getCadenciaMaxima()
    {

        return ratio;

    }

    public float getPuntosPorUtilizar()
    {
        return currentPoints;
    }
    public void setPuntosPorUtilizar(float cant)
    {

        currentPoints = cant;

    }
    public string getComienzo()
    {
        return comienzo;
    }
    public float getRondaComienzo()
    {
        return rondaComienzo;
    }

    public float getStaminaPoints()
    {
        return staminaPoints;
    }
    public float getLifePoints()
    {
        return lifePoints;
    }
    public float getRatioPoints()
    {
        return ratioPoints;
    }
}
