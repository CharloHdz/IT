using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidadm = 5;
    public float velocidadr = 100;
    public KeyCode moverAdelante = KeyCode.W;
    public KeyCode moverAtras = KeyCode.S;
    public KeyCode moverIzquierda = KeyCode.A;
    public KeyCode moverDerecha = KeyCode.D;

    void Start()
    {
        // Cualquier código adicional que necesites para inicializar tu personaje
    }

    void Update()
    {
        mover();
    }

    public void mover()
    {
        if (Input.GetKey(moverAdelante))
        {
            transform.Translate(0, 0, velocidadm * Time.deltaTime);
        }
        if (Input.GetKey(moverAtras))
        {
            transform.Translate(0, 0, -velocidadm * Time.deltaTime);
        }
        if (Input.GetKey(moverIzquierda))
        {
            transform.Rotate(0, -velocidadr * Time.deltaTime, 0);
        }
        if (Input.GetKey(moverDerecha))
        {
            transform.Rotate(0, velocidadr * Time.deltaTime, 0);
        }
    }
}
