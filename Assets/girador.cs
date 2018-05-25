using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girador : MonoBehaviour
{
    float modificado = 0f;
    public float duracionActivacionBolasGiratorias;
    private float bolasRestantes = 4f;
    
    // Use this for initialization
    void Start()
    {
        

        //float modificado = 0;
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 laNeta = new Vector3(0f, 0f, 1f);
        modificado += 4f;
        transform.rotation = Quaternion.AngleAxis(modificado, laNeta);

        if (bolasRestantes == 0)
        {

            GameObject.Find("GameController").GetComponent<SpawnPowerups>().contadorDuracionBolas = duracionActivacionBolasGiratorias;
            setNumInicialBolas(4f);
            //ponemos el tiempo igual al limite para que acabe ya
            /*
            GameObject.Find("GameController").GetComponent<SpawnPowerups>().desactivarGiradorBolas();
            GameObject.Find("GameController").GetComponent<SpawnPowerups>().nuevoSpawneoGiradorBolas = false;
            GameObject.Find("GameController").GetComponent<SpawnPowerups>().setTimerAparicionBolasGiratorias(Random.Range(10, 30));
            GameObject.Find("GameController").GetComponent<SpawnPowerups>().contadorSpawnBolasGiratorias = 0;
            */
        }

    }
    public float getBolasRestantes()
    {
        return bolasRestantes;
    }
    public void SetUnaBolaMenos()
    {
        bolasRestantes--;
        print(bolasRestantes);
    }
	public void setNumInicialBolas(float value)
    {
        bolasRestantes = value;
    }
   
}