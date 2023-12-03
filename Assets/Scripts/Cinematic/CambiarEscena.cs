using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public float tiempoEspera = 3f; // Tiempo de espera en segundos
    public string nombreEscena = "NombreDeLaEscena"; // Nombre de la escena a la que quieres cambiar
    //public Animator anim;

    private float tiempoInicio;

    private void Start()
    {
        tiempoInicio = Time.time;
        //anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // Si ha pasado el tiempo de espera, cambia de escena
        if (Time.time - tiempoInicio >= tiempoEspera)
        {
            StartCoroutine(SceneLoad(nombreEscena));
        }
    }

    public IEnumerator SceneLoad(string nombreEscena){
        //anim.SetBool("transition", true);
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(nombreEscena);
    }
}
