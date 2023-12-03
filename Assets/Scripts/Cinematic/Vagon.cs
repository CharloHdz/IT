using UnityEngine;

public class Vagon : MonoBehaviour
{
    public float velocidad = 5f; // La velocidad del vagón

    void Start()
    {
        // Asignar la velocidad al vagón
        GetComponent<Rigidbody>().velocity = new Vector3(-velocidad, 0f, 0f);
    }
}

