using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5f;
    public float minDistanceToPlayer = 2f;
    private GameObject player;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    public float capsuleRadius = 0.5f;
    public float capsuleHeight = 2f;
    public float raycastDistance = 1f;

    private void Start()
{
    // Buscar al jugador por su nombre
    player = GameObject.Find("Player");
    if (player == null)
    {
        Debug.LogError("No se ha encontrado al objeto del jugador en la escena.");
    }
}

private void Update()
{
    if (player == null)
    {
        return;
    }

    // Calcular la dirección hacia el jugador
    Vector3 playerDirection = (player.transform.position - transform.position).normalized;

    // Verificar si la distancia es mayor que la distancia mínima de separación
    float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
    if (distanceToPlayer <= minDistanceToPlayer)
    {
        // No mover la inteligencia artificial si está muy cerca del jugador
        return;
    }

    SetGravity();

    // Calcular la dirección actual de la inteligencia artificial en el plano horizontal
    Vector3 currentDirection = transform.forward;
    currentDirection.y = 0;
    currentDirection.Normalize();

    // Calcular la rotación que se debe aplicar en el eje vertical
    float angle = Vector3.SignedAngle(currentDirection, playerDirection, Vector3.up);
    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);

    // Realizar Raycast en la dirección de movimiento
    RaycastHit hit;
    CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();
    bool hitWall = Physics.CapsuleCast(transform.position + capsuleCollider.center - capsuleCollider.height * transform.up / 2f, transform.position + capsuleCollider.center + capsuleCollider.height * transform.up / 2f, capsuleRadius, transform.forward, out hit, raycastDistance);
    if (hitWall && hit.distance <= raycastDistance - capsuleRadius)
    {
        // Si se detecta una colisión y está a una distancia menor a la distancia de rayo - radio de cápsula, detener el movimiento del enemigo
        transform.position = hit.point - transform.forward * capsuleRadius;
    }
    else{

        // Aplicar la rotación y mover la inteligencia artificial en la dirección calculada
        transform.rotation *= rotation;
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }

    Debug.Log("Enemy direction: " + transform.forward);
    Debug.Log("Player direction: " + playerDirection);

}

void SetGravity(){

    movePlayer.y = -gravity * Time.deltaTime;
}

   
}


