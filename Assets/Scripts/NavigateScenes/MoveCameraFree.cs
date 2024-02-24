using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraFree : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float sensibilidadMouse = 2f;

    private float rotacionX = 0f;

    void Start()
    {
        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Movimiento de la cámara con las teclas AWSD
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical) * velocidadMovimiento * Time.deltaTime;
        transform.Translate(movimiento);

        // Subir y bajar la cámara con las teclas Q y E
        float movimientoVerticalQE = 0f;
        if (Input.GetKey(KeyCode.Q))
        {
            movimientoVerticalQE = -1f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            movimientoVerticalQE = 1f;
        }

        Vector3 movimientoVerticalVector = new Vector3(0f, movimientoVerticalQE, 0f) * velocidadMovimiento * Time.deltaTime;
        transform.Translate(movimientoVerticalVector, Space.World);

        // Rotación de la cámara con el mouse
        float rotacionHorizontal = Input.GetAxis("Mouse X") * sensibilidadMouse;
        rotacionX -= Input.GetAxis("Mouse Y") * sensibilidadMouse;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        transform.Rotate(Vector3.up * rotacionHorizontal);

    }
}
