using UnityEngine;
using System.Collections.Generic;

public class ScreenManager : MonoBehaviour
{
    public List<GameObject> objetos;
    public int currentMenu = 0;

    public void ChangeObject(int gameObjectIndex)
    {
        // Desactiva todos los objetos
        foreach (GameObject objeto in objetos)
        {
            objeto.SetActive(false);
        }

        // Activa el objeto seleccionado
        if (gameObjectIndex >= 0 && gameObjectIndex < objetos.Count)
        {
            currentMenu = gameObjectIndex;
            objetos[currentMenu].SetActive(true);
        }
    }
}

