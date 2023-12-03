using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public List<GameObject> menus;
    public int currentMenu = 0;
    public GameObject mensaje;
    public GameObject principal;

    public void ToggleMenu()
    {
        if (menus[currentMenu].activeSelf)
        {
            // Si el menú actual está activado, lo desactivamos
            menus[currentMenu].SetActive(false);
        }
        else
        {
            // Si el menú actual está desactivado, lo activamos
            menus[currentMenu].SetActive(true);
        }
    }

    public void MostrarOpciones(){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mensaje);
    }
    public void CerrarOpciones(){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(principal);
    }
}

