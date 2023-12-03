using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent navMeshAgent;
    private bool isAttacking;

    [SerializeField] private float attackDistance = 2f;

    private void Start() {
        player = GameObject.FindWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        navMeshAgent.SetDestination(player.position);

        // Raycast para detectar obstáculos
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, navMeshAgent.radius)) {
            if (hit.collider.gameObject.CompareTag("Obstacle")) {
                // Si hay un obstáculo, cambiar la dirección al jugador
                navMeshAgent.SetDestination(player.position);
            }
        }

        if (navMeshAgent.remainingDistance <= attackDistance) {
            // El enemigo ha llegado al jugador
            navMeshAgent.isStopped = true;
            if (!isAttacking) {
                isAttacking = true;
                // Activar el ataque
                Debug.Log("Atacando");
            }
        } else {
            navMeshAgent.isStopped = false;
            if (isAttacking) {
                isAttacking = false;
                // Desactivar el ataque
                Debug.Log("Dejando de atacar");
            }
        }
    }
}
