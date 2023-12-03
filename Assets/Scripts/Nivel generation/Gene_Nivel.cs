using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene_Nivel : MonoBehaviour
{
    [SerializeField] private GameObject[] partesNivel;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private Transform puntoFinal;
    [SerializeField] private int cantidadInicial;
    private Transform jugador;

    // Start is called before the first frame update
    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < cantidadInicial; i++)
        {
            GenerarParteNivel();
        }
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(jugador.position, puntoFinal.position) < distanciaMinima)
        {
            //Debug.Log(distancia);
            GenerarParteNivel();
        }
     
    }

    private void GenerarParteNivel()
    {
        int numeroAleatorio = Random.Range(0, partesNivel.Length);
        GameObject nivel = Instantiate(partesNivel[numeroAleatorio], puntoFinal.position, Quaternion.identity);
        puntoFinal = BuscarPuntoFinal(nivel, "PuntoFinal");
    }
    private Transform BuscarPuntoFinal(GameObject parteNivel,string etiqueta)
    {
        Transform punto = null;
        foreach(Transform ubicacion in parteNivel.transform)
        {
            if (ubicacion.CompareTag(etiqueta))
            {
                punto = ubicacion;
                break;
            }
        }
        return punto;
    }
}
