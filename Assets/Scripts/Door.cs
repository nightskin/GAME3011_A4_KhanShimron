using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool locked;
    public float speed = 5;

    Vector3 open1;
    Vector3 open2;
    Vector3 dest;
    void Start()
    {
        locked = true;
        open1 = new Vector3();
        open2 = new Vector3();
        
        open1 = transform.position + Vector3.forward;
        open2 = open1 + new Vector3(0, 3, 0);
        dest = open1;
    }

    void Update()
    {
        if(!locked)
        {
            if (transform.position != dest)
            {
                transform.position = Vector3.Lerp(transform.position, dest, 0.1f);
            }    
            else
            {
                dest = open2;
            }

        }
    }
}
