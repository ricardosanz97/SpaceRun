using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas : MonoBehaviour {

    // Update is called once per frame
    public GameObject sistema1;
    public GameObject sistema2;
	void Update () {
		if (Input.GetKey(KeyCode.LeftShift))
        {
            sistema1.GetComponent<ParticleSystem>().Play();
            sistema2.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            sistema1.GetComponent<ParticleSystem>().Stop();
            sistema2.GetComponent<ParticleSystem>().Stop();
        }
	}
}
