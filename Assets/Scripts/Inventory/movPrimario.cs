using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movPrimario : MonoBehaviour
{

    public Transform target;
    public float speed = 1.0f;
    public float x, y;
    public int band = 1;
    Vector3 mov = new Vector3(0, 5, 0);
    void Update()
    {
        float step = 1f;
        if (band < 20)
        {

            transform.position += mov;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else if (band >= 20 && band < 40)
        { 
            transform.position -= mov;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else if (band >= 40)
        {
            band++;
        }
        if(band >= 500)
        {
            band = 0;
        }
        band++;
        
        
    }

}
