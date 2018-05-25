using UnityEngine;
using System.Collections;

public class Disparador : MonoBehaviour {

    public float permiso;

    private float contadorBalasUsadas = 0f;

    public float danyo;
    private float tiempoDisparo = 0f; 
    Transform puntoDisparo;
    Transform puntoDisparoIzdo;

    public GameObject Bullet;

	// Use this for initialization
	void Start () {

        //DontDestroyOnLoad(this.gameObject);
        puntoDisparo = transform.Find("FirePoint");
        puntoDisparoIzdo = transform.Find("FirePointIzdo");
        if (puntoDisparo == null || puntoDisparoIzdo==null)
        {
            Debug.LogError("No firepoint");
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (permiso == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Disparar();
            }
        }
        else
        {
            if (Input.GetMouseButton(0) && Time.time > tiempoDisparo)
            {
                tiempoDisparo = Time.time + 1 / permiso;
                Disparar();
            }
        }
    }
    void Disparar()
    {
        Vector2 firePointPosition = new Vector2(puntoDisparo.position.x, puntoDisparo.position.y);
        Vector2 firePointPosition2 = new Vector2(puntoDisparoIzdo.position.x, puntoDisparoIzdo.position.y);
        Effect();
    }
    void Effect()
    {  
        Instantiate(Bullet, puntoDisparo.position, puntoDisparo.rotation);
        Instantiate(Bullet, puntoDisparoIzdo.position, puntoDisparoIzdo.rotation);

        contadorBalasUsadas += 2;
    }

    public float getBalasUsadas()
    {
        return contadorBalasUsadas;

    }
    public float getCadencia()
    {
        return permiso;
    }
    public void setCadencia(float value)
    {

        permiso = value;
    }
}
