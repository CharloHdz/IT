using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    public string sceneName; // Nombre de la escena a recargar

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Cuando se presiona el botón asignado a "Fire1"
        {
            SceneManager.LoadScene(sceneName); // Cargar la escena especificada
        }
    }
}

