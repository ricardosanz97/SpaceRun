using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Salud : MonoBehaviour {

    public Image barra;

    public float max;
    private void Start()
    {
        max = barra.fillAmount;
    }

    public void SetVida(float cuanto)
    {
		barra.fillAmount -= cuanto;
    }
    public void regeneraVida()
    {
        barra.fillAmount = max;
    }
}
