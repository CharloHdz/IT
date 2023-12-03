using UnityEngine;

public class GeneradorDeVagones : MonoBehaviour
{
    public GameObject Vagon; // El prefab del vagón que se instanciará
    private float distanciaEntreVagones = 10f; // La distancia entre cada vagón del tren
    private float limiteGeneracion = 50f; // La distancia a la que se generará un nuevo vagón
    private Vector3 posicionVagon; // La posición del último vagón generado

    void Start()
    {
        // Instanciar el primer vagón del tren
        GameObject primerVagon = Instantiate(Vagon, transform.position, Quaternion.identity);
        // Almacenar la posición del vagón para generar los siguientes
        posicionVagon = primerVagon.transform.position;
    }

    void Update()
    {
        // Mover el tren hacia la izquierda (o la dirección que desees)
        transform.position -= new Vector3(5f * Time.deltaTime, 0f, 0f);

        // Comprobar si es necesario generar un nuevo vagón
        if (Vector3.Distance(transform.position, posicionVagon) > limiteGeneracion)
        {
            // Generar un nuevo vagón
            GameObject nuevoVagon = Instantiate(Vagon, posicionVagon + new Vector3(distanciaEntreVagones, 0f, 0f), Quaternion.identity);
            // Actualizar la posición del último vagón generado
            posicionVagon = nuevoVagon.transform.position;
        }

        // Eliminar los vagones que ya no son visibles
        foreach (Transform vagon in transform)
        {
            if (vagon.position.x < transform.position.x - 50f)
            {
                Destroy(vagon.gameObject);
            }
        }
    }
}

