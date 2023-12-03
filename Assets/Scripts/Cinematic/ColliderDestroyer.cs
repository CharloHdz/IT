using UnityEngine;

public class ColliderDestroyer : MonoBehaviour
{
    public string objectTag = "Train"; // Etiqueta del objeto que se destruirá al atravesar el collider

    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que atraviesa el collider tiene la etiqueta especificada, se destruye
        if (other.CompareTag(objectTag))
        {
            other.gameObject.SetActive(false);
        }
    }
}
