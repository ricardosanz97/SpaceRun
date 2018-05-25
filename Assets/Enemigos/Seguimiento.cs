using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguimiento : MonoBehaviour
{

    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    private Transform myTransform;

    // Use this for initialization
    void Awake()
    {
        myTransform = transform;
    }

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if (go != null)
        {
            target = go.transform;
        }
        else
        {
            print("No hay objetivo");
        }

    }

    // Update is called once per frame
    void Update()
    {
        GameObject nave = GameObject.FindGameObjectWithTag("Player");


        if (nave != null)
        {
            Vector3 dir = target.position - myTransform.position;
            dir.z = 0.0f; // Only needed if objects don't share 'z' value


            if (dir != Vector3.zero)
            {
                myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
                                                         Quaternion.FromToRotation(Vector3.up, dir), rotationSpeed * Time.deltaTime);
            }

            //Move Towards Target
            myTransform.position += (target.position - myTransform.position).normalized * moveSpeed * Time.deltaTime;

        }
    }
}
