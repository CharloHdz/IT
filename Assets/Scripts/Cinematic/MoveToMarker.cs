using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMarker : MonoBehaviour
{
    public GameObject targetMarker; // El objeto marcador al que se moverá el personaje
    public GameObject targetLogo;
    public GameObject logo;
    public float speed = 5.0f; // La velocidad a la que se moverá el personaje
    public Animator animator;
    private float blend;
    private Vector3 startPosition;


    private void Start(){
        animator = GetComponent<Animator>();
        startPosition = transform.position;
    }

    private void Update()
    {
        // Calcula la dirección en la que debe moverse el personaje
        Vector3 direction = targetMarker.transform.position - transform.position;

        // Si el personaje aún no ha alcanzado el marcador, lo mueve hacia él
        if (direction.magnitude > 0.1f)
        {
            blend = 0;
            animator.SetFloat("Blend", blend);
            transform.position = Vector3.MoveTowards(transform.position, targetMarker.transform.position, speed * Time.deltaTime);

            // Calcula la distancia total que debe recorrer el personaje
            float totalDistance = Vector3.Distance(startPosition, targetMarker.transform.position);

            // Calcula la distancia que ha recorrido el personaje hasta ahora
            float currentDistance = Vector3.Distance(startPosition, transform.position);

            // Calcula la fracción del recorrido que ha completado el personaje
            float fraction = Mathf.InverseLerp(0, totalDistance, currentDistance);

            // Establece el valor de "blend" usando la fracción del recorrido completado
            blend = (int)Mathf.Lerp(0, 1, fraction);
            animator.SetFloat("Blend", blend);

        }else{
            blend = 1;
            animator.SetFloat("Blend", blend);

            /*Vector3 targetLogoPosition = targetLogo.transform.position;
            float lerpSpeed = 0.2f; // Velocidad de movimiento de la cámara (0.0 a 1.0)
            logo.transform.position = Vector3.Lerp(logo.transform.position, targetLogoPosition, lerpSpeed * Time.deltaTime);

            /* // Calcula la rotación del ángulo X de la cámara
            float targetCameraRotation = -50.0f;
            float currentCameraRotation = targetCamera.transform.eulerAngles.x;
            float newCameraRotation = Mathf.Lerp(currentCameraRotation, targetCameraRotation, lerpSpeed * Time.deltaTime);

            // Establece la rotación de la cámara
            Vector3 newCameraEulerAngles = new Vector3(newCameraRotation, targetCamera.transform.eulerAngles.y, targetCamera.transform.eulerAngles.z);
            Camera.main.transform.eulerAngles = newCameraEulerAngles;*/
        }
    }
}
