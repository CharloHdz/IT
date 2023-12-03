using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralRoomGenerator : MonoBehaviour
{

    public Vector3 posicionInicio;
    public float ancho;
    public float alto;
    public GameObject prefabMuro;
    
    private void Start()
    {
        GenerarMuros();
    }

    void GenerarMuros() {
    float anchoMuro = prefabMuro.transform.localScale.x;
    float altoMuro = prefabMuro.transform.localScale.y;

    int murosNorte = Mathf.RoundToInt(ancho / anchoMuro);
    int murosSur = Mathf.RoundToInt(ancho / anchoMuro);
    int murosEste = Mathf.RoundToInt(alto / altoMuro);
    int murosOeste = Mathf.RoundToInt(alto / altoMuro);

    // Muros norte
    Vector3 posicionActual = posicionInicio;
    for (int i = 0; i < murosNorte; i++) {
        posicionActual.x += (i == 0) ? anchoMuro / 2 : anchoMuro;
        Vector3 posicion = new Vector3(posicionActual.x, posicionActual.y, posicionActual.z);
        Collider[] colliders = Physics.OverlapBox(posicion, prefabMuro.GetComponent<BoxCollider>().size / 2, Quaternion.identity);
        if (colliders.Length == 0) {
            Instantiate(prefabMuro, posicion, Quaternion.identity);
        }
    }

    // Muros sur
    posicionActual = new Vector3(posicionInicio.x, posicionInicio.y, posicionInicio.z + alto - altoMuro);
    for (int i = 0; i < murosSur; i++) {
        posicionActual.x += (i == 0) ? anchoMuro / 2 : anchoMuro;
        Vector3 posicion = new Vector3(posicionActual.x, posicionActual.y, posicionActual.z);
        Collider[] colliders = Physics.OverlapBox(posicion, prefabMuro.GetComponent<BoxCollider>().size / 2, Quaternion.identity);
        if (colliders.Length == 0) {
            Instantiate(prefabMuro, posicion, Quaternion.identity);
        }
    }

    // Muros este
    posicionActual = new Vector3(posicionInicio.x + ancho - anchoMuro, posicionInicio.y, posicionInicio.z);
    for (int i = 0; i < murosEste; i++) {
        posicionActual.z += (i == 0) ? altoMuro / 2 : altoMuro;
        Vector3 posicion = new Vector3(posicionActual.x, posicionActual.y, posicionActual.z);
        Collider[] colliders = Physics.OverlapBox(posicion, prefabMuro.GetComponent<BoxCollider>().size / 2, Quaternion.Euler(0f, 90f, 0f));
        if (colliders.Length == 0) {
            Instantiate(prefabMuro, posicion, Quaternion.Euler(0f, 90f, 0f));
        }
    }

    // Muros oeste
    posicionActual = new Vector3(posicionInicio.x, posicionInicio.y, posicionInicio.z);
    for (int i = 0; i < murosOeste; i++) {
        posicionActual.z += (i == 0) ? altoMuro / 2 : altoMuro;
        Vector3 posicion = new Vector3(posicionActual.x, posicionActual.y, posicionActual.z);
        Collider[] colliders = Physics.OverlapBox(posicion, prefabMuro.GetComponent<BoxCollider>().size / 2, Quaternion.Euler(0f, 90f, 0f));
        if (colliders.Length == 0) {
            Instantiate(prefabMuro, posicion, Quaternion.Euler(0f, 90f, 0f));
        }
    }
}

}
